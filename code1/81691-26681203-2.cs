    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace Namespace {
    
    
    // use the Add(Control, "Title"); method to add controls to the accordion
    public class Accordion : Control {
    
    	public static String GlobalDownArrow = "\u25bc  "; // used if instance value DownArrow is null
    	public static String GlobalUpArrow = "\u25b2  "; // used if instance value UpArrow is null
    
    	// Note: tried using TableLayoutPanel before, but it incorrectly displays its scrollbars
    	private FlowLayoutPanel2 host = new FlowLayoutPanel2 { FlowDirection = FlowDirection.TopDown, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink };
    	private Control2 lastChecked = null; // used to track the last opened control so it can be closed if OpenOneOnly is true
    	private ToolTip tips = new ToolTip();
    	private ToolBox toolBox = new ToolBox();
    	// used when OpenOneOnly is true. The previously open one is automatically closed which fires a checkedchanged event.
    	// isAdjusting is used to avoid responding to that event.
    	private bool isAdjusting = false;
    
    	public bool OpenOneOnly { get; set; } // only allows one to be expanded at a time
    	public bool FillResetOnCollapse { get; set; } // collapsing automatically removes the extra height next time the content is opened
    	public bool FillModeGrowOnly { get; set; } // extra height is strictly increasing and is not decreased (except by the user)
    	public bool FillLastOpened { get; set; } // the last eligible content receives all the extra space
    	public Padding? ContentPadding { get; set; } // default padding to apply
    	public String DownArrow { get; set; } // gets or sets the text to prefix to the checkbox text when the content is hidden
    	public String UpArrow { get; set; } // gets or sets the text to prefix to the checkbox text when the content is visible
    	// if true, then the user can resize the content height of an open header by dragging the bottom of the content, like
    	// a split container. The splitter width is the value of ContentPadding.Bottom.
    	public bool AllowMouseResize { get; set; }
    	// when the mouse hovers over the rightmost side of an open header which has a fill weight > 0,
    	// a tool menu is displayed which gives the user the ability to control the height
    	public bool ShowToolMenu { get; set; }
    
    	public Accordion() {
    		this.AutoSize = true;
    		this.SetAutoSizeMode(AutoSizeMode.GrowAndShrink); // doesn't seem to be required, but keep anyway
    		//this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
    		host.Dock = DockStyle.Fill;
    		this.Dock = DockStyle.Fill;
    		host.Margin = new Padding(0);
    		host.Padding = new Padding(0);
    		this.Controls.Add(host);
    		this.ContentPadding = new Padding(5); // whitespace between edges
    		host.AutoScroll = true;
    		this.ShowToolMenu = true;
    		//this.AutoScroll = true;
    		host.WrapContents = false; // must disable to prevent wrap when scrollbars appear
    		this.AllowMouseResize = true;
    	}
    
    	protected override void OnFontChanged(EventArgs e) {
    		base.OnFontChanged(e);
    		toolBox.Font = this.Font;
    	}
    
    	private class ToolBox : ToolStripDropDown {
    		ToolStripMenuItem miShrink = new ToolStripMenuItem("\u2191") { ToolTipText = "Pack" }; // up arrow
    		ToolStripMenuItem miFill = new ToolStripMenuItem("\u2193") { ToolTipText = "Expand" }; // down arrow
    		ToolStripMenuItem miLock = new ToolStripMenuItem("\u1f512");
    
    		Control2 _c2 = null;
    
    		public Control2 Current {
    			get {
    				return _c2;
    			}
    			set {
    				_c2 = value;
    				if (_c2 != null) {
    					if (_c2.isLocked) {
    						miLock.ToolTipText = "Unlock height.";
    						miLock.Text = "\uD83D\uDD13";
    					}
    					else {
    						miLock.ToolTipText = "Lock height.";
    						miLock.Text = "\uD83D\uDD12";
    					}
    				}
    			}
    		}
    
    		public ToolBox() {
    			miShrink.Anchor = AnchorStyles.Left | AnchorStyles.Right;
    			miFill.Anchor = AnchorStyles.Left | AnchorStyles.Right;
    			miLock.Anchor = AnchorStyles.Left | AnchorStyles.Right;
    
    			this.Items.Add(miShrink);
    			this.Items.Add(miFill);
    			this.Items.Add(miLock);
    
    			this.DropShadowEnabled = false;
    			this.BackColor = Color.Transparent;
    			this.Padding = new Padding(0, 2, 1, 2); // remove extra left pixel on left side
    
    			miFill.Click += delegate {
    				FlowLayoutPanel2 host = (FlowLayoutPanel2) Current.Parent;
    				foreach (Control c in host.Controls) {
    					if (c is Control2) {
    						Control2 c2 = (Control2) c;
    						if (!c2.isLocked)
    							c2.dh = 0;
    					}
    				}
    				Current.lastClicked = DateTime.Now;
    				bool origLocked = Current.isLocked;
    				Current.isLocked = false;
    				host.UpdateDeltaHeights();
    				Current.isLocked = origLocked;
    				host.PerformLayout();
    			};
    
    			miShrink.Click += delegate {
    				Current.dh = 0;
    				Current.lastClicked = DateTime.MinValue;
    				FlowLayoutPanel2 host = (FlowLayoutPanel2) Current.Parent;
    				bool origLocked = Current.isLocked;
    				Current.isLocked = true;
    				host.UpdateDeltaHeights();
    				Current.isLocked = origLocked;
    				host.PerformLayout();
    			};
    
    			miLock.Click += delegate {
    				Current.isLocked = !Current.isLocked;
    				FlowLayoutPanel2 host = (FlowLayoutPanel2) Current.Parent;
    				host.UpdateDeltaHeights();
    				host.PerformLayout();
    			};
    		}
    	}
    
    	// It's possible to listen for the Resize event, but then the scrollbars will flicker.
    	// Subclassing provides much nicer behavior.
    	private class FlowLayoutPanel2 : FlowLayoutPanel {
    		// For FlowLayoutPanel, the dummyControl is used to set to be the width of the host so that the
    		// checkboxes that use Anchor = AnchorStyles.Left | AnchorStyles.Right will fill to the edges.
    		private Control dummyControl = new Control() { Margin = Padding.Empty };
    		internal bool addDH = true;
    
    		public FlowLayoutPanel2() {
    			this.Controls.Add(dummyControl);
    		}
    
    		protected override void OnFontChanged(EventArgs e) {
    			UpdateDeltaHeights(); // call before base method to prevent the
    			PerformLayout();	  // the vertical scrollbar from briefly showing
    			base.OnFontChanged(e);
    		}
    
    		private Size getPreferredSizeNoDH() {
    			addDH = false;
    			Size s = GetPreferredSize(Size.Empty);
    			addDH = true;
    			return s;
    		}
    
    		public void UpdateDeltaHeights() {
    			Accordion acc = (Accordion) this.Parent;
    			UpdateDeltaHeights(acc.FillLastOpened, acc.FillModeGrowOnly, acc.FillResetOnCollapse);
    		}
    
    		public void UpdateDeltaHeights(bool fillLastOpened, bool fillModeGrowOnly, bool fillResetOnCollapse) {
    			Size r = getPreferredSizeNoDH();
    			Size cs = this.ClientSize;
    
    			double totalWt = 0;
    			int mh = 0; // minus height
    			foreach (Control c in this.Controls) {
    				if (c is Control2) {
    					Control2 c2 = (Control2) c;
    					if (c2.cb.Checked) {
    						if (c2.isLocked)
    							mh += c2.dh;
    						else
    							totalWt += c2.fillWt;
    					}
    				}
    			}
    
    			int eh = Math.Max(0, (cs.Height - r.Height) - mh);
    
    			if (fillLastOpened) {
    				Control2 fc = getFillControl();
    
    				foreach (Control c in this.Controls) {
    					if (c is Control2) {
    						Control2 c2 = (Control2) c;
    						if (c2.isLocked) // height is locked, do nothing
    							continue;
    
    						if (c2 == fc) {
    							if (fillModeGrowOnly) {
    								if (eh > c2.dh)
    									c2.dh = eh;
    							}
    							else {
    								c2.dh = eh;
    							}
    						}
    						else {
    							if (fillResetOnCollapse)
    								c2.dh = 0;
    						}
    					}
    				}
    			}
    			else {
    				double pixels = 0; // pixel perfect
    				foreach (Control c in this.Controls) {
    					if (c is Control2) {
    						Control2 c2 = (Control2) c;
    						if (c2.isLocked) // height is locked, do nothing
    							continue;
    
    						// if totalWt is zero, that means no controls with a fillWt are currently open
    						// thus if fillResetOnCollapse is true, then their dh values should be reset to zero
    						if (c2.cb.Checked && totalWt > 0) {
    							double ddh = c2.fillWt * eh / totalWt;
    							int dh = (int) ddh;
    							pixels += ddh % 1;
    							if (pixels >= 0.5) {
    								dh++;
    								pixels--;
    							}
    							if (fillModeGrowOnly) {
    								if (dh > c2.dh)
    									c2.dh = dh;
    								else {} // do nothing
    							}
    							else
    								c2.dh = dh;
    						}
    						else {
    							if (fillResetOnCollapse)
    								c2.dh = 0;
    						}
    					}
    				}
    			}
    		}
    
    		private Control2 getFillControl() {
    			Control2 cc = null;
    			foreach (Control c in this.Controls) {
    				if (c is Control2) {
    					Control2 c2 = (Control2) c;
    					if (c2.isLocked) // don't return a locked control to fill
    						continue;
    
    					if (c2.fillWt > 0 && c2.cb.Checked) {
    						if (cc == null)
    							cc = c2;
    						else if (c2.lastClicked > cc.lastClicked)
    							cc = c2;
    					}
    				}
    			}
    			return cc;
    		}
    
    		// The anchor styles in FlowLayoutPanel work in reference to the widest control
    		// or tallest control. Thus, a dummy control is required. The checkboxes will
    		// expand to width of the dummyControl. If the available area is made smaller,
    		// then the checkboxes will be as wide as the checkbox with the longest text and
    		// scrollbars will appear.
    		protected override void OnSizeChanged(EventArgs e) {
    			UpdateDeltaHeights(); // required to fill
    			dummyControl.Width = this.ClientSize.Width;
    			base.OnSizeChanged(e);
    		}
    
    	}
    
    	// returns the first control that has no children and is Enabled
    	private static Control GetFirstFocus(Control c) {
    		foreach (Control c2 in c.Controls) {
    			var c3 = GetFirstFocus(c2);
    			if (c3.Enabled)
    				return c3;
    		}
    
    		return c;
    	}
    
    	private String GetDownArrow() {
    		return (this.DownArrow == null ? GlobalDownArrow : this.DownArrow);
    	}
    
    	private String GetUpArrow() {
    		return (this.UpArrow == null ? GlobalUpArrow : this.UpArrow);
    	}
    
    	// fillWt specifies that the control should be vertically expanded if there is extra
    	// height available. There are two different modes:
    	// 1) The last opened content that has fillWt > 0 will receive any extra height.
    	//    All other opened contents appear at their preferred size.
    	// 2) The extra height is distributed between open contents that have fillWt > 0
    	//    and are not locked by the user. The fillWt divided by the sum of open-unlocked
    	//    fillWts determines the exact distribution.
    	public void Add(Control c, String text, String toolTip = null, double fillWt = 0, bool expand = false) {
    		String da = GetDownArrow();
    		String ua = GetUpArrow();
    
    		// AutoSize must be true or the text will wrap under and be hidden
    		var cb = new CheckBox { Appearance = Appearance.Button, Text = da + text, AutoSize = true };
    		cb.Anchor = AnchorStyles.Left | AnchorStyles.Right; // cb.Dock = DockStyle.Fill also works.
    		cb.Margin = new Padding(0); // otherwise there are gaps between the buttons
    
    		var c2 = new Control2(cb, c, fillWt) { Dock = DockStyle.Fill };
    
    		if (ContentPadding.HasValue)
    			c2.Padding = ContentPadding.Value;
    
    		if (!String.IsNullOrEmpty(toolTip))
    			tips.SetToolTip(cb, toolTip);
    
    		host.Controls.Add(cb);
    		host.Controls.Add(c2);
    
    		cb.MouseHover += delegate {
    			if (ShowToolMenu && cb.Checked && c2.fillWt > 0 && !toolBox.Visible) {
    				var p1 = cb.PointToClient(Control.MousePosition);
    				if (p1.X >= cb.Width - toolBox.Width) {
    					Point p = new Point { X = cb.Width - toolBox.Width, Y = cb.Height };
    					toolBox.Current = c2;
    					toolBox.Show(cb, p);
    				}
    			}
    		};
    
    		cb.MouseUp += (o, e) => {
    			if (ShowToolMenu && cb.Checked && c2.fillWt > 0 && e.Button == MouseButtons.Right) {
    				var p1 = cb.PointToClient(Control.MousePosition);
    				int w = toolBox.Width;
    				p1.X -= w/2;
    				p1.Y -= w/2;
    				toolBox.Current = c2;
    				toolBox.Show(cb, p1);
    			}
    		};
    
    		DateTime leaveTime;
    		toolBox.MouseLeave += delegate {
    			// the tooltip of a menu item causes a mouse leave, so
    			// confirm the mouse is outside of the bounds before hiding
    			leaveTime = DateTime.Now;
    			new System.Threading.Thread((o) => {
    				// allow the mouse to leave for up to 1 second before closing
    				System.Threading.Thread.Sleep(1000);
    				if ((DateTime) o != leaveTime)
    					return;
    
    				toolBox.BeginInvoke((Action) delegate {
    					if (!toolBox.Bounds.Contains(Control.MousePosition)) {
    						toolBox.Hide();
    					}
    				});
    			}).Start(leaveTime);
    		};
    
    		cb.MouseLeave += delegate {
    			if (toolBox.Visible) {
    				// since toolBox has no parent, its bounds are in screen coordinates
    				if (!toolBox.Bounds.Contains(Control.MousePosition))
    					toolBox.Hide();
    			}
    		};
    
    		cb.CheckedChanged += delegate {
    			String a = (cb.Checked ? GetUpArrow() : GetDownArrow());
    			cb.Text = a + text; // must set text regardless of isAdjusting
    
    			if (cb.Checked)
    				c2.lastClicked = DateTime.Now;
    
    			if (isAdjusting)
    				return;
    
    			// for some reason, when the scrollbar first appears, it scrolls an
    			// amount equal to the ContentPadding.Left to the right. Also, the scroll
    			// value resets to 0 right before the checkbox is changed, so it's not
    			// easy to know what the previous value is.
    			//int hsorig = 0;
    			//if (host.HorizontalScroll.Visible)
    			//	hsorig = host.HorizontalScroll.Value;
    
    			if (OpenOneOnly) {
    				if (lastChecked != null && cb.Checked && c2 != lastChecked) {
    					isAdjusting = true;
    					lastChecked.cb.Checked = false;
    					isAdjusting = false;
    				}
    			}
    
    			lastChecked = c2;
    			host.UpdateDeltaHeights();
    			host.AutoScroll = false; // forces proper refresh
    			host.AutoScroll = true;
    			host.Invalidate(true);
    			host.PerformLayout();
    			GetFirstFocus(c).Focus();
    
    			if (host.HorizontalScroll.Visible) {
    				// something causes the scrollbar to scroll to the right by an amount equal
    				// to the ContentPadding.Left value.
    				host.AutoScrollPosition = Point.Empty;
    			}
    		};
    
    		// wait for all controls to be added before expanding if currently not visible
    		if (expand) {
    			if (this.Visible)
    				cb.Checked = true;
    			else
    				this.HandleCreated += delegate {
    					cb.Checked = true;
    				};
    		}
    	}
    
    	// cannot subclass Control directly because then the Padding isn't used
    	private class Control2 : ScrollableControl {
    		internal CheckBox cb;
    		Control c;
    		internal int dh = 0;
    		internal double fillWt = 0;
    		internal DateTime lastClicked = DateTime.MinValue;
    		internal bool isLocked = false;
    		Cursor cursorResize = Cursors.SizeNS;
    		Point oldPoint = Point.Empty;
    		bool isGrabbing = false;
    		Point grabPoint = Point.Empty;
    		int dhOrig;
    		bool resetLocked = false; // only lock a control if it was actually moved
    		bool origLocked = false; // just clicking on the splitter must not lock
    
    		public Control2(CheckBox cb, Control c, double fillWt) {
    			this.cb = cb;
    			this.c = c;
    			this.fillWt = fillWt;
    			this.AutoSize = true;
    			//this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
    			this.SetAutoSizeMode(AutoSizeMode.GrowAndShrink);
    			this.Controls.Add(c);
    			this.Margin = new Padding(0); // otherwise default is (3)
    		}
    
    		protected override void OnMouseMove(MouseEventArgs e) {
    			base.OnMouseMove(e);
    
    			FlowLayoutPanel2 p = (FlowLayoutPanel2) this.Parent;
    			Accordion acc = (Accordion) p.Parent;
    			if (!acc.AllowMouseResize)
    				return;
    
    			// PerformLayout causes the control to move which triggers a MouseMove
    			// even though the mouse didn't move. Thus, the absolute location is
    			// used to determine if the mouse actually moved. There is probably a
    			// better way to handle the resizing.
    			Point pt = this.PointToScreen(e.Location);
    			if (oldPoint == pt)
    				return;
    			oldPoint = pt;
    
    			if (isGrabbing) {
    				int dy = pt.Y - grabPoint.Y;
    				dh = Math.Max(0, dhOrig + dy);
    				p.UpdateDeltaHeights();
    				p.PerformLayout();
    				resetLocked = false;
    			}
    			else {
    				int by = this.Height - e.Y;
    				if (by < this.Padding.Bottom)
    					this.Cursor = cursorResize;
    				else
    					this.Cursor = this.DefaultCursor;
    			}
    		}
    
    		protected override void OnMouseDown(MouseEventArgs e) {
    			base.OnMouseDown(e);
    			if (this.Cursor == cursorResize) {
    				isGrabbing = true;
    				dhOrig = dh;
    				origLocked = isLocked;
    				resetLocked = true;
    				isLocked = true;
    				grabPoint = this.PointToScreen(e.Location);
    			}
    		}
    
    		protected override void OnMouseUp(MouseEventArgs e) {
    			base.OnMouseUp(e);
    			this.Cursor = this.DefaultCursor;
    			isGrabbing = false;
    			if (resetLocked)
    				isLocked = origLocked;
    		}
    
    		public override Size GetPreferredSize(Size proposedSize) {
    			if (!cb.Checked) return Size.Empty;
    			Size s = c.GetPreferredSize(proposedSize);
    			var pd = this.Padding;
    			FlowLayoutPanel2 p = (FlowLayoutPanel2) this.Parent;
    			s.Width += pd.Left + pd.Right;
    			s.Height += pd.Top + pd.Bottom + (p.addDH ? dh : 0);
    			return s;
    		}
    	}
    
    	public override Size GetPreferredSize(Size proposedSize) {
    		return host.GetPreferredSize(proposedSize);
    	}
    
    	protected override void Dispose(bool disposing) {
    		base.Dispose(disposing);
    		if (disposing) {
    			tips.Dispose();
    			tips = null;
    
    			toolBox.Dispose();
    			toolBox = null;
    		}
    	}
    
    	// optional idea to provide a custom control to expand / collapse the content...
    	// however, it must always extend checkbox, or this control must track the state
    	// of the toggle, so too much work for now.
    	//public interface IControlFactory {
    	//	Control CreateHeaderControl(String text);
    	//}
    	//public class DefaultControlFactory : IControlFactory {
    	//	public Control CreateHeaderControl(String text) {
    	//		return 
    	//	}
    	//}
    }
    }

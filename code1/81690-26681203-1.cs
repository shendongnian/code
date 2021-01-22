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
    
    	private FlowLayoutPanel2 host = new FlowLayoutPanel2 { FlowDirection = FlowDirection.TopDown, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink };
    	private Control2 lastChecked = null; // used to track the last opened control so it can be closed if OnlyOneOpen is true
    	public bool OnlyOneOpen { get; set; } // only allows one to be expanded at a time
    	public Padding? ContentPadding { get; set; } // default padding to apply
    	public String DownArrow { get; set; } // gets or sets the text to prefix to the checkbox text when the content is hidden
    	public String UpArrow { get; set; } // gets or sets the text to prefix to the checkbox text when the content is visible
    
    	private ToolTip tips = new ToolTip();
    
    	public Accordion() {
    		this.AutoSize = true;
    		this.SetAutoSizeMode(AutoSizeMode.GrowAndShrink); // doesn't seem to be required, but keep anyway
    		host.Dock = DockStyle.Fill;
    		this.Dock = DockStyle.Fill;
    		host.Margin = new Padding(0);
    		host.Padding = new Padding(0);
    		this.Controls.Add(host);
    		this.ContentPadding = new Padding(5); // whitespace between edges
    		host.AutoScroll = true;
    		//OnlyOneOpen = true;
    		host.WrapContents = false; // must disable to prevent wrap when scrollbars appear
    	}
    
    	// it's possible to listen for the Resize event, but then the scrollbars will flicker
    	// subclassing provides much nicer behavior
    	private class FlowLayoutPanel2 : FlowLayoutPanel {
    		// For FlowLayoutPanel, the dummyControl is used to set to be the width of the host so that the checkboxes 
    		// that use Anchor = AnchorStyles.Left | AnchorStyles.Right will fill to the edges.
    		private Control dummyControl = new Control() { Margin = Padding.Empty };
    
    		// this variable prevents a Control2 from adjusting its height when the this.PreferredSize is called
    		// in the OnSizeChanged method. Otherwise there is scrollbar jitter because the sizes are adjusting
    		// as the size is changed.
    		internal bool isAdjusting = false;
    
    		public FlowLayoutPanel2() {
    			this.Controls.Add(dummyControl);
    		}
    
    		// The anchor styles in FlowLayoutPanel work in reference to the widest control
    		// or tallest control. Thus, a dummy control is required. The checkboxes will
    		// expand to width of the dummyControl. If the available area is made smaller,
    		// then the checkboxes will be as wide as the checkbox with the longest text and
    		// scrollbars will appear.
    		protected override void OnSizeChanged(EventArgs e) {
    			int w = this.Width;
    			// this prevents the horizontal scrollbar from showing
    			isAdjusting = true;
    			var s = this.PreferredSize;
    			isAdjusting = false;
    			var cs = this.ClientSize;
    			int h2 = cs.Height;
    			if (h2 <= s.Height - 1)
    				w -= SystemInformation.HorizontalScrollBarArrowWidth;
    			dummyControl.Width = w;
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
    
    	// fillHeight specifies that the control should be vertically expanded if there is extra
    	// height available. The last control clicked/expanded will receive the extra height.
    	public void Add(Control c, String text, String toolTip = null, bool fillHeight = false) {
    		String da = GetDownArrow();
    		String ua = GetUpArrow();
    
    		// AutoSize must be true or the text will wrap
    		var cb = new CheckBox { Appearance = Appearance.Button, Text = da + text, AutoSize = true };
    		cb.Anchor = AnchorStyles.Left | AnchorStyles.Right;
    
    		//cb.Dock = DockStyle.Fill;
    		cb.Margin = new Padding(0); // otherwise there are gaps between the buttons
    
    		var c2 = new Control2(cb, c, fillHeight) { Dock = DockStyle.Fill };
    
    		if (ContentPadding.HasValue)
    			c2.Padding = ContentPadding.Value;
    
    		if (!String.IsNullOrEmpty(toolTip))
    			tips.SetToolTip(cb, toolTip);
    
    		host.Controls.Add(cb);
    		host.Controls.Add(c2);
    		cb.CheckedChanged += delegate {
    			host.PerformLayout();
    			GetFirstFocus(c).Focus();
    
    			if (OnlyOneOpen) {
    				if (lastChecked != null && cb.Checked && c2 != lastChecked)
    					lastChecked.cb.Checked = false;
    
    				lastChecked = c2;
    			}
    
    			String a = (cb.Checked ? GetUpArrow() : GetDownArrow());
    			cb.Text = a + text;
    		};
    	}
    
    	private class Control2 : Panel {
    		internal CheckBox cb;
    		Control c;
    		int dh = 0;
    		bool fillHeight;
    		DateTime lastClicked = DateTime.MinValue;
    		bool flag = false;
    
    		public Control2(CheckBox cb, Control c, bool fillHeight) {
    			this.cb = cb;
    			this.c = c;
    			this.fillHeight = fillHeight;
    			this.AutoSize = true;
    			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
    			this.Controls.Add(c);
    			this.Margin = new Padding(0); // otherwise default is (3)
    
    			cb.CheckedChanged += delegate {
    				if (cb.Checked && fillHeight)
    					lastClicked = DateTime.Now;
    			};
    		}
    
    		public override Size GetPreferredSize(Size proposedSize) {
    			if (!cb.Checked) return Size.Empty;
    			Size s = c.GetPreferredSize(proposedSize);
    			var p = this.Padding;
    			s.Width += p.Left + p.Right;
    			s.Height += p.Top + p.Bottom + dh;
    			FlowLayoutPanel2 p2 = (FlowLayoutPanel2) this.Parent;
    			if (flag || !fillHeight || p2.isAdjusting)
    				return s;
    
    			foreach (Control cc in p2.Controls) {
    				if (cc is Control2) {
    					if (((Control2) cc).lastClicked > this.lastClicked)
    						return s;
    				}
    			}
    
    			flag = true;
    			var r = p2.GetPreferredSize(proposedSize);
    			int h1 = p2.Height;
    			dh = Math.Max(h1 - r.Height, 0);
    			flag = false;
    			s.Height += dh;
    
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

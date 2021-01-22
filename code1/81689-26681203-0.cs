    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace Namespace {
    
    // use the Add(Control, "Title"); method to add controls to the accordion
    public class Accordion : Panel {
    
    	public static String GlobalDownArrow = "\u25bc  ";
    	public static String GlobalUpArrow = "\u25b2  ";
    
    	private FlowLayoutPanel host = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink };
    	private Control2 lastChecked = null;
    	public bool OnlyOneOpen { get; set; } // only allows one to be expanded at a time
    	public Padding? ContentPadding { get; set; } // default padding to apply
    	public String DownArrow { get; set; } // gets or sets the text to prefix to the checkbox text when the content is hidden
    	public String UpArrow { get; set; } // gets or sets the text to prefix to the checkbox text when the content is visible
    
    	private ToolTip tips = new ToolTip();
    
    	public Accordion() {
    		this.AutoSize = true;
    		this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
    		host.Dock = DockStyle.Fill;
    		this.Controls.Add(host);
    		this.ContentPadding = new Padding(5); // whitespace between edges
    		//OnlyOneOpen = true;
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
    
    	public void Add(Control c, String text, String toolTip = null) {
    		String da = GetDownArrow();
    		String ua = GetUpArrow();
    
    		var cb = new CheckBox { Appearance = Appearance.Button, Text = da + text, AutoSize = true, Anchor = AnchorStyles.Left | AnchorStyles.Right };
    		cb.Margin = new System.Windows.Forms.Padding(0);
    		var c2 = new Control2(cb, c) { Anchor = AnchorStyles.Left | AnchorStyles.Right }; // anchor is required to fill to sides
    
    		if (ContentPadding.HasValue)
    			c2.Padding = ContentPadding.Value;
    
    		if (!String.IsNullOrEmpty(toolTip))
    			tips.SetToolTip(cb, toolTip);
    
    		//c2.BackColor = Color.Purple;
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
    		public Control2(CheckBox cb, Control c) {
    			this.cb = cb;
    			this.c = c;
    			this.AutoSize = true;
    			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
    			this.Controls.Add(c);
    			this.Margin = new Padding(0); // otherwise default is (3)
    		}
    
    		public override Size GetPreferredSize(Size proposedSize) {
    			if (!cb.Checked) return Size.Empty;
    			Size s = c.GetPreferredSize(proposedSize);
    			var p = this.Padding;
    			s.Width += p.Left + p.Right;
    			s.Height += p.Top + p.Bottom;
    			return s;
    		}
    	}
    
    	public override Size GetPreferredSize(Size proposedSize) {
    		Size s = new Size();
    		foreach (Control c in this.Controls) {
    			var s2 = c.GetPreferredSize(Size.Empty);
    			s.Height += s2.Height;
    			if (s2.Width > s.Width)
    				s.Width = s2.Width;
    		}
    		return s;
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

	/// <summary>
	/// This class provides custom rendering code for the ToolStrip and ToolStripDropDownButton because the standard windows
	/// rendering gave it a very flat look.
	/// </summary>
	public class CustomToolStripRenderer : ToolStripRenderer {
		ToolStripDropDownButton toolStripDDButton;
		public CustomToolStripRenderer(ToolStripDropDownButton toolStripDropDownButton)	: base() {
			toolStripDDButton = toolStripDropDownButton;
		}
		//protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs tsirea) {
		//    // Check if the item is selected or hovered over.
		//    if (tsirea.Item.Selected || tsirea.Item.Pressed) {
		//        LinearGradientBrush brush = new LinearGradientBrush(tsirea.Item.Bounds, Color.DarkBlue, Color.DarkGreen, 90);
		//        tsirea.Graphics.FillRectangle(brush, 0, 0, tsirea.Item.Width, tsirea.Item.Height);
		//    }
		//}
		protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs tsrea) {
			// This event occurs before the OnRenderDropDownButtonBackground event...
			if (toolStripDDButton.Pressed) {
				base.OnRenderToolStripBackground(tsrea);
			}
			else if (toolStripDDButton.Selected) {
				ControlPaint.DrawButton(tsrea.Graphics, tsrea.AffectedBounds, ButtonState.Normal);
			}
			else {
				ControlPaint.DrawButton(tsrea.Graphics, tsrea.AffectedBounds, ButtonState.Normal);
			}
		}
  
		//protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs tsirea) {
		//    // Happens every time the button is hovered over as well, and upon mouseleave
		//    //ControlPaint.DrawButton(tsirea.Graphics, tsirea.Item.ContentRectangle, ButtonState.Normal);
		//    base.OnRenderDropDownButtonBackground(tsirea);
		//}
		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs tsrea) {
			//This event occurs after the OnRenderDropDownButtonBackground event...
			//Thus it will paint over whatever is already painted in the OnRenderDropDownButtonBackground event.
			//Debug.Println("OnRenderToolStripBorder");
			if (toolStripDDButton.Pressed) {
				// Draw the top and left borders of the component so that it looks like a tab page:
				tsrea.Graphics.DrawLine(SystemPens.ControlDarkDark, tsrea.AffectedBounds.Left, tsrea.AffectedBounds.Top, tsrea.AffectedBounds.Left, tsrea.AffectedBounds.Bottom);
				tsrea.Graphics.DrawLine(SystemPens.ControlDarkDark, tsrea.AffectedBounds.Left, tsrea.AffectedBounds.Top, tsrea.AffectedBounds.Right, tsrea.AffectedBounds.Top);
			}
			base.OnRenderToolStripBorder(tsrea);
		}
	}

	public class ButtonRadioButton : RadioButton {
		
		protected override void OnPaint(PaintEventArgs e) {
			PushButtonState state;
			if (this.Checked)
				state = PushButtonState.Pressed;
			else
				state = PushButtonState.Normal;
			ButtonRenderer.DrawButton(e.Graphics, e.ClipRectangle, state);
		}
	}

    public class CustomComboBox : ComboBox
    {
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            
            int left = this.Width - (SystemInformation.HorizontalScrollBarThumbWidth + SystemInformation.HorizontalResizeBorderThickness);
            if (e.X >= left)
            {
                // They did click the button, so let it happen.
                base.OnMouseClick(e);
            }
            else
            {
                // They didn't click the button, so prevent the dropdown.
                // Just do nothing.
            }
        }
    }

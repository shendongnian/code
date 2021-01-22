    using System.Windows.Forms
    //optional namespace
    
    public class NoTabTextBox : TextBox
    {
        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Tab:
                    return true;
            }
            return base.IsInputKey(keyData);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab) { e.Handled = true; e.SuppressKeyPress = true; }
            base.OnKeyDown(e);
        }
    }

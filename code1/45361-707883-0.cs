    public class nonRepeatingTextBox : TextBox
    {
        private bool keyDown = false;
        protected override void OnKeyUp(KeyEventArgs e)
        {
            keyDown = false;
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (keyDown)
            {
                e.SuppressKeyPress = true;
            }
            keyDown = true;
        }
    }

    public class EnterTextBox : TextBox
    {
        [Browsable(true), EditorBrowsable]
        public event EventHandler EnterKeyPressed;
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                EnterKeyPressed?.Invoke(this, EventArgs.Empty);
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }

    public class MyTextBox : TextBox
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter || keyData == Keys.Return)
            {
                // Perform validation here
                return true;
            }
            else
                return false;
        }
    }

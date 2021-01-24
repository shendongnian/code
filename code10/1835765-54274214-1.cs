    public class MyForm
    {
        // this method may also be in a different class
        public static bool ValidateName(string name, out string errorMessage)
        {
            errorMessage = null;
            if (name == "")
            {
                errorMessage = "enter your name";
                return false;
            }
            return true;
        }
        public int validation()
        {
            int flag = 0;
            string errorMessage;
            if (!ValidateName(name.Text, out errorMessage))
            {
                name.Focus();
                errorProvider1.SetError(name, MessageBox.Show(errorMessage, "error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }
            // ...
        }
    }

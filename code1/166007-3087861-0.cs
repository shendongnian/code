    public class OptionsDialog : Form
    {
        private static OptionsDialog openForm = null;
        // No need for locking - you'll be doing all this on the UI thread...
        public static OptionsDialog GetInstance() 
        {
            if (openForm == null)
            {
                openForm = new OptionsDialog();
                openForm.FormClosed += delegate { openForm = null; };
            }
            return openForm;
        }
    }

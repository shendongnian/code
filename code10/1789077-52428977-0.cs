    public static class OpenFileDialogExtensions
    {
        public static string ShowDialogAndReturnFileName(this OpenFileDialog dialog)
        {
            // consider checking arguments
            dialog.ShowDialog();
            return dialog.FileName;
        }
    }
    // Usage, just like you want:
    pathTextBox.Text = new OpenFileDialog().ShowDialogAndReturnFileName();

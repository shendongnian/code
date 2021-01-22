    partial class MainForm : Form // this is MainForm.cs
    {
        // This is the method VS generates when you double-click the button
        private void clearButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                FormCleaner cleaner = new FormCleaner();
                cleaner.ClearForm(this);
            }
            catch(Exception ex)
            {
                // ... have here code to log the exception to a file 
                // and/or showing a message box to the user
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }

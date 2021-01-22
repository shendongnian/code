    partial class MainForm : Form // this is MainForm.cs
    {
        // This is the method VS generates when you double-click the button
        private void clearButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ClearForm();
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
        private void ClearForm()
        {
            // clear all your controls here
            myTextBox.Clear();
            myComboBox.SelectedIndex = 0;
            // etc...
        }
    }

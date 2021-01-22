        private void BForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //If the user is closing the form via another means than the OK button, or the Cancel button (e.g.: Top-Right-X, Alt+F4, etc).
            if (this.DialogResult != DialogResult.OK && this.DialogResult != DialogResult.Ignore)
            {
                //check if dirty first... 
                if (this.UserKey.IsDirty)
                {
                    if (MessageBox.Show("You have unsaved changes. Close and lose changes?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        e.Cancel = true;
                }
            }
        }

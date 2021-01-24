        private void btnClose_Click(object sender, EventArgs e)
        {
            if (unsavedChanges)
            {
                var result = MessageBox.Show("Save changes?", "unsaved changes", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveChanges();
                }
                if (result == DialogResult.Cancel)
                {
                    result = DialogResult.None;
                }
                this.DialogResult = result;
            }
        }

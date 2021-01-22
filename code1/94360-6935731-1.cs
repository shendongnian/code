     private void frmAddImages_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (DialogResult != DialogResult.OK)
        {
            if (IsDirty)
            {
                e.Cancel = !(MessageBox.Show("Are you sure that you want to exit without saving", "Form Not Saved", MessageBoxButtons.YesNo) == DialogResult.Yes);
            }
        }
        }
		

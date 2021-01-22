    private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLastName.Text.Trim() == String.Empty)
            {
                errorProvider1.SetError(txtLastName, "Last Name is Required");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtLastName, "");
        }

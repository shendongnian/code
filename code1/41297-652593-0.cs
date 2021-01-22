    private void SelectText()
        {
            TextBox tb = this.txtFirstName;
            tb.SelectionStart = 0;
            tb.SelectionLength = 3;
            // tb.Select(0, this.txtFirstName.Text.Trim().Length - 1);
            // tb.SelectAll();
            // tb.Text = String.Empty;
            tb.Focus();
        }

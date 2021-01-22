      private void LeaveEvent(object sender, EventArgs e)
      {
         if (String.IsNullOrEmpty(tbUsername.Text))
         {
            tbUsername.Text = USER_NAME;
            tbUsername.ForeColor = SystemColors.InactiveCaption;
            this.Focus();
            tbUsername.TextAlign = HorizontalAlignment.Center;
         }
      }

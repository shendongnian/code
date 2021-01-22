        private void tbUsername_Leave(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(OnLeave));
        }
        private void OnLeave()
        {
            if (tbUsername.Text == String.Empty)
            {
                tbUsername.TextAlign = HorizontalAlignment.Center;
                tbUsername.ForeColor = SystemColors.InactiveCaption;
                tbUsername.Text = "Username";
            }
        }

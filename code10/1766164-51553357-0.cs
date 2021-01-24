      public MyForm() 
      {
        InitializeComponent();
        // At most 11 characters
        TxtID.MaxLength = 11;
      }
      private void TxtID_KeyPress(object sender, KeyPressEventArgs e)
      {
        // char.IsDigit is too wide: it returns true on any unicode digit (e.g. Persian ones)
        e.Handled = (e.KeyChar < '0' || e.KeyChar > 9) && !char.IsControl(e.KeyChar);          
      }
      // On Paste we should validate the input:
      // what if user copy "bla-bla-bla 1234" and paste it to TxtID?
      private void TxtID_TextChanged(object sender, EventArgs e) 
      {
        Control ctrl = (sender as Control);
        string value = string.Concat(ctrl
          .Text
          .Where(c => c >= '0' && c <= '9'));
        if (value != ctrl.Text)
          ctrl.Text = value;
      }

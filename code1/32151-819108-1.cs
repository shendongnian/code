    private void zip_txt_KeyPress(object sender, KeyPressEventArgs e)
    {
       if (!(Char.IsDigit(e.KeyChar)))
       {
          e.Handled = true;
       }
       else
       {
          e.Handled = false;
       }
    }

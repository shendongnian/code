    private bool DecimalOnly_KeyPress(TextBox txt, bool numeric, KeyPressEventArgs e)
    {
      if (numeric)
      {
        // only allow numbers
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))     
          return true;
      }
      else
      {
        // allow a minus sign if it's the first character or the entire text is selected
        if (e.KeyChar == '-' && (txt.Text == "" || txt.SelectedText == txt.Text))
          return false;
        // if a decimal point is entered and if one is not already in the string
        if ((e.KeyChar == '.') && (txt.Text.IndexOf('.') > -1))                     
        {
          if (txt.SelectedText.IndexOf('.') > -1)
            // allow a decimal point if the selected text contains a decimal point, that is the
            // decimal point replaces the selected text 
            return false;
          else
            // don't allow a decimal point if one is already in the string and the selected text
            // doesn't contain one
            return true;                                                        
        }
        // if the entry is not a digit
        if (!Char.IsDigit(e.KeyChar))                                               
        {
          // if it's not a decimal point and it's not a backspace then disallow
          if ((e.KeyChar != '.') && (e.KeyChar != Convert.ToChar(Keys.Back)))     
          {
            return true;
          }
        }
      }
      // allow only a minus sign but only in the beginning, only one decimal point, any digit, a
      // backspace, and replace selected text.
      return false;                                                                   
    }

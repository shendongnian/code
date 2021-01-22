    private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      Char pressedKey = e.KeyChar;
      if (Char.IsLetter(pressedKey) || Char.IsSeparator(pressedKey) || Char.IsPunctuation(pressedKey))
      {
        // Allow input.
        e.Handled = false
      }
      else
        // Stop the character from being entered into the control since not a letter, nor punctuation, nor a space.
        e.Handled = true;
      }
    }

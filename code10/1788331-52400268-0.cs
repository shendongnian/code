      if (int.TryParse(textBox3.Text, out var v3) &&
          int.TryParse(textBox2.Text, out var v2) &&
          numericUpDown1.Value >= int.MinValue && numericUpDown1.Value <= int.MaxValue) {
        // All three values are valid integers
        label1.Text = (numericUpDown1.Value + v3 + v2).ToString();  
      }
      else {
        // At least one value is not an Int32
        label1.Text = "???";
      }

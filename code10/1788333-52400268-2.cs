      if (int.TryParse(textBox3.Text, out var v3) &&
          int.TryParse(textBox2.Text, out var v2) &&
          numericUpDown1.Value >= int.MinValue && numericUpDown1.Value <= int.MaxValue) {
        // All three values are valid integers
        // The result will be Decimal, that's why we can skip 
        // IntegerOverflowException prevention.
        // Order matters: 0m + 2_000_000_000 + 2_000_000_000 = 4_000_000_000m
        //                2_000_000_000 + 2_000_000_000 + 0m - Exception (overflow)
        label1.Text = (numericUpDown1.Value + v3 + v2).ToString();  
      }
      else {
        // At least one value is not a valid Int32
        label1.Text = "???";
      }

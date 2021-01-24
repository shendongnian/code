      foreach (var button in Controls.OfType<Button>()) {
        button.Click += (ss, ee) => {
          Button myButton = ss as Button;
          myButton.ForeColor = System.Drawing.Color.Red;
          myButton.Enabled = false;
        };
      }

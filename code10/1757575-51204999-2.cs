      for (int line = 0; line < 7; ++line) {
        for (int column = 0; column < 10; ++column) {
          Button button = new Button() {
            Parent = this,
            Text = "?", // Here you to generate button's text, e.g. with Random   
            Location = new Point(50 + line * 40, 50 + column * 40),
            Size = new Size(30, 30),
          };
          button.Click += (ss, ee) => {
            Button myButton = ss as Button;
            myButton.ForeColor = System.Drawing.Color.Red;
          };
        }
      }

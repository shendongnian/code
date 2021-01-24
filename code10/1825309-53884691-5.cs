      for (int i = 0; i < 5; ++i) {
        new Button {
          Size = new Size(50, 50),
          Location = new Point(40 + i * 60, 100),
          Text = $"{i}", 
          BackColor = SystemColors.Control,
          Parent = this, 
        }.Click += (ss, ee) => {
          // Lambda: what shall we do on click
          MessageBox.Show($"{(ss as Control).Text} clicked!");
        };
      }

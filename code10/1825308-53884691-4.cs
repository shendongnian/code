     for (int i ....) { // whatever loop
        ...
        new Button {
          Size = new Size(50, 50),
          Location = new Point(40 + i * 60, 100),
          Text = $"{i}", // May appear more readable than i.ToString()
          BackColor = c, 
          Parent = this, // <- instead of this.Controls.Add
        }.Click += eventforshowingmessage;
        ...
      }

    private void button1_Click(object sender, EventArgs e) {
      // Give the 3 checkboxes a decent spacing
      int height = this.Font.Height * 3 / 2;
      // Create the panel first, add it to the form
      Panel pnl = new Panel();
      pnl.Size = new Size(100, 3 * height);
      pnl.Location = new Point(10, 5);
      this.Controls.Add(pnl);
      // Make three checkboxes now
      for (int ix = 0; ix < 3; ++ix) {
        CheckBox box = new CheckBox();
        box.Size = new Size(100, height);
        // As pointed out, avoid overlapping them
        box.Location = new Point(0, ix * height);
        box.Text = "Option #" + (ix + 1).ToString();
        box.Tag = ix;
        // We want to know when the user checked it
        box.CheckedChanged += new EventHandler(box_CheckedChanged);
        // The panel is the container
        pnl.Controls.Add(box);
      }
    }
    void box_CheckedChanged(object sender, EventArgs e) {
      // "sender" tells you which checkbox was checked
      CheckBox box = sender as CheckBox;
      // I used the Tag property to store contextual info, just the index here
      int index = (int)box.Tag;
      // Do something more interesting here...
      if (box.Checked) {
        MessageBox.Show(string.Format("You checked option #{0}", index + 1));
      }
    }

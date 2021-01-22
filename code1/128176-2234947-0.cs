    shapes[i].Dock = DockStyle.Fill;
    flowLayoutPanel1.Controls.Add(
        new Panel {
            Controls = {
                shapes[i],
                new Label {
                    Dock = DockStyle.Bottom,
                    Text = i.ToString()
                }
            }
        });

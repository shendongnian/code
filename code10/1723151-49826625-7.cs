    private void Form1_Load(object sender, EventArgs e)
    {
        var padSpace = 5;
        var height = 15;
        // Add 10 labels, with a common tag on every other one
        for (int i = 0; i < 10; i++)
        {
            Controls.Add(new Label
            {
                Text = $"Label {i}",
                Top = padSpace * (i + 1) + height * i,
                Height = height,
                Visible = true,
                Tag = i % 2 == 0 ? "deleteMe" : "saveMe"
            });
        }
        // Add a button that will delete controls with deleteMe tag
        var btn = new Button
        {
            Text = "Delete Even Labels",
            Height = 20,
            Width = 150,
            Top = padSpace * 11 + height * 10,
            Visible = true
        };
        btn.Click += (o, ea) => { DeleteControlsWithTag("deleteMe"); };
        Controls.Add(btn);
    }

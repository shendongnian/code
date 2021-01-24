    private void button1_Click(object sender, EventArgs e)
    {
        games += 1;
        LocPoint += 1;
        Label label = new Label
        {
            Name = "game_" + games,
            Text = "New Game",
            Cursor = Cursors.Hand,
            Location = new Point(25, LocPoint * 24),
            AutoSize = true
        };
        Controls.Add(label);
        label.Click += Label_Click;

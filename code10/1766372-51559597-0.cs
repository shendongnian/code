    // Generating 5x5 button grid
    void Spawn5x5Grid()
    {
        // position of the firts tile
        int x = 35, y = 55;
        // current tile index
        int count = 0;
        for (int i = 1; i < 6; i++)
        {
            for (int j = 1; j < 6; j++)
            {
                // Adding button to the array
                tiles25[count] = new Button()
                {
                    Size = new Size(24, 24),
                    Location = new Point(x, y)
                };
                // Adding buttons from array to the form
                Controls.Add(tiles25[count]);
                tiles25[count].Click += Tiles25_Click;
                count++;
                x = x + 24;
            }
            x = 35;
            y = y + 24;
        }
        lblSize.Text = "5 x 5";
        currentGrid = Grids.grid5x5;
    }
    private void Tiles25_Click(object sender, EventArgs e)
    {
        var bt = sender as Button;
        MessageBox.Show("X = " + bt.Location.X + "; Y = " + bt.Location.Y);
    }

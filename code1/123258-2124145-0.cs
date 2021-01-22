        const int spacing = 50;
        Label[][] map = new Label[3][];
        for (int x = 0; x < 3; x++)
        {
            map[x] = new Label[3];
            for (int y = 0; y < 3; y++)
            {
                map[x][y] = new Label();
                map[x][y].AutoSize = true;
                map[x][y].Location = new System.Drawing.Point(x * spacing, y * spacing);
                map[x][y].Name = "map" + x.ToString() + "," + y.ToString();
                map[x][y].Size = new System.Drawing.Size(spacing, spacing);
                map[x][y].TabIndex = 0;
                map[x][y].Text = x.ToString() + y.ToString();
            }
            this.Controls.AddRange(map[x]);
        }
        map[1][1].Text = "Test";

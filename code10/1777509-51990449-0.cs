    private void Form1_Load(object sender, EventArgs e)
    {
        int gridWidth = 75;
        int gridHeight = 50;
        int controlSize = 20;
        int row = 0;
        for (int i = 1; i < gridWidth * gridHeight; i++)
        {
            var value = ((char) i).ToString();
            Controls.Add(new Button
            {
                Left = i % gridWidth * controlSize,
                Top = row * controlSize,
                Width = controlSize,
                Height = controlSize,
                Text = value
            });
            if (i % gridWidth == 0) row++;
        }
    }

    Label label = new Label();
    this.Controls.Add(label);
    label.Size = new Size(500, 500); // Enter custom size or use Graphics.MeasureString method to find proper size dynamically
    label.AutoSize = false;
    label.Font = new Font("Consolas", 8);
    for (int i = 0; i < map.GetLength(0); i++)
    {
        for (int j = 0; j < map.GetLength(1); j++)
        {
            label.Text += map[i, j].PadLeft(5, ' ');
        }
        label.Text += Environment.NewLine;
    }

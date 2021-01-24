    private void Form1_Load(object sender, EventArgs e)
    {
        var list = new[] {
            new { C1 = "A", C2 = -2 },
            new { C1 = "B", C2 = -1 },
            new { C1 = "C", C2 = 0 },
            new { C1 = "D", C2 = 1 },
            new { C1 = "E", C2 = 2 },
        }.ToList();
        dataGridView1.DataSource = list;
        zero = new Bitmap(16, 16);
        using (var g = Graphics.FromImage(zero))
            g.Clear(Color.Silver);
        negative = new Bitmap(16, 16);
        using (var g = Graphics.FromImage(negative))
            g.Clear(Color.Red);
        positive = new Bitmap(16, 16);
        using (var g = Graphics.FromImage(positive))
            g.Clear(Color.Green);
        //Set padding to have enough room to draw image
        dataGridView1.Columns[1].DefaultCellStyle.Padding = new Padding(18, 0, 0, 0);
    }

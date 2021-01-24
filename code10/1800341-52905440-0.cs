    public static Graphics g;
    public static Bitmap bmp;
    
    DataTable dt = new DataTable();
    
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        if (dt.Columns.Count == 0)
        {
            dt.Columns.Add("xPoint", typeof(float));
            dt.Columns.Add("yPoint", typeof(float));
            dt.Columns.Add("character", typeof(string));
        }
        else
        {
            if (lblX.ForeColor == Color.Red)
            {
                dt.Rows.Add(e.Location.X - 5, e.Location.Y - 10, "x");
            }
            else if (lblZ.ForeColor == Color.Red)
            {
                dt.Rows.Add(e.Location.X - 5, e.Location.Y - 10, "z");
            }
            if (lblX.ForeColor == Color.Red || lblZ.ForeColor == Color.Red)
            {
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                g = Graphics.FromImage(bmp);
                DataRow lastRow = dt.Rows[dt.Rows.Count - 1];
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                foreach (DataRow row in dt.Rows)
                {
                    g.DrawString(row[2].ToString(), new Font("Tahoma", 12), Brushes.Red, float.Parse(row[0].ToString()), float.Parse(row[1].ToString()));
                }
                g.Flush();
                pictureBox1.Image = bmp;
            }
        }
    }

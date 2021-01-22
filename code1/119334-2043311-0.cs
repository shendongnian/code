    private void button1_Click(object sender, EventArgs e)
    {
        int thumbSize = 16;
        SortedList<Color, int> colors = 
            new SortedList<Color, int>(new ColorComparer());
        Image thumbImg = pictureBox1.Image.GetThumbnailImage(
            thumbSize, thumbSize, ThumbnailCallback, IntPtr.Zero);
        Bitmap thumbBmp = new Bitmap(thumbImg);
        for (int i = 0; i < thumbSize; i++)
        {
            for (int j = 0; j < thumbSize; j++)
            {
                Color col = thumbBmp.GetPixel(i, j);
                if (colors.ContainsKey(col))
                    colors[col]++;
                else
                    colors.Add(col, 1);
            }                
        }
        List<string> colorNames = new List<string>();
        foreach (KeyValuePair<Color, int> colorIntPair in colors)
            colorNames.Add(colorIntPair.Key.ToString());
        string top10Colors = "";
        for (int i = 0; i < 10; i++)
            top10Colors += "\n" + i + ". " + colorNames[i];
        MessageBox.Show("Top 10 Colors: " + top10Colors);
    }
    public bool ThumbnailCallback() { return false; }
    private class ColorComparer : IComparer<Color> 
    {
        public int Compare(Color x, Color y) {
            return x.ToArgb().CompareTo(y.ToArgb());
        }
    }

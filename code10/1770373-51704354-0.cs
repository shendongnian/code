    var img = new Bitmap(pictureBox1.Image);
    var sb = new StringBuilder();
    
    for (int i = 0; i < img.Height; i++)
    {
        for (int j = 0; j < img.Width; j++)
        {
            if (img.GetPixel(j, i).ToArgb() == Color.White.ToArgb())
            {
                sb.Append("0");
            }
            else
            {
                sb.Append("1");
            }
        }
    }
    
    richTextBox1.Text = sb.ToString();

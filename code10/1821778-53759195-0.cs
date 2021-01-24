    private void button1_Click(object sender, EventArgs e)
    {
        using (FileStream stream = File.OpenRead(FullName))
        {
            pictureBox1.Image = Bitmap.FromStream(stream);
        }
    }

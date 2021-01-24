    private void pictureBox1_Click(object sender, EventArgs e)
    {
        if (((MouseEventArgs)e).X <= pictureBox1.Image.Width &&
            ((MouseEventArgs)e).Y <= pictureBox1.Image.Height)
        {
            MessageBox.Show("Valid Click");
        }
    } 

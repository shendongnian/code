    private void button1_Click(object sender, EventArgs e)
    {
       OpenFileDialog open = new OpenFileDialog();
       open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.png; *.bmp)|*.jpg; *.jpeg; *.gif; *.png; *.bmp";
       if (open.ShowDialog() == DialogResult.OK)
       {
          Bitmap tmp = new Bitmap(open.FileName);
    
          if(tmp.Height >= pictureBox1.Height || tmp.Width >= pictureBox1.Width)
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
    
          pictureBox1.Image = tmp;
                    
       }
    }

     private void InsertPicture_Click(object sender, EventArgs e)
        {
                        {
                if (openFileDialog4.ShowDialog() == DialogResult.OK)
                {
                    // Show the Open File dialog. If the user clicks OK, load the 
                    // picture that the user chose.   
                    pictureBox2.Load(openFileDialog4.FileName);
                    Clipboard.SetImage(pictureBox2.Image);
                    pictureBox2.Image = null;
                    this.richTextBox1.Paste();
                    
                }
        }
    }

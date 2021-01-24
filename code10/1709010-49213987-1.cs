    private void Form2_Load(object sender, EventArgs e)
            {
                if(ImageCompareArray((Bitmap)button1.BackgroundImage, (Bitmap)button2.BackgroundImage))
                {
                    MessageBox.Show("Yes");
                }
                else
                {
                    MessageBox.Show("No");
                }
            }

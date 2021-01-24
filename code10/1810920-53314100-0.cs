    private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
                //Creates a filter fir saving the Project File
                save.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp); *.PNG|*.jpg; *.jpeg; *.gif; *.bmp; *.PNG";     
                save.DefaultExt = ".bmp";
                save.AddExtension = true;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (var bmp = new Bitmap(pictureBox_Canvass.Width, pictureBox_Canvass.Height))
                    {
                        pictureBox_Canvass.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                        bmp.Save(save.FileName);
                    }
                }
        }

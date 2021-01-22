                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter = "Images|*.jpg ; *.png ; *.bmp";
                ImageFormat format = ImageFormat.Jpeg;
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    
                    switch (sv.Filter )
                    {
                        case ".jpg":
                            format = ImageFormat.Png;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    
                   
                    pictureBox.Image.Save(sv.FileName, format);
                }

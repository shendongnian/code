            if (mybitmap != null)
            {
                SaveFileDialog SaveFD1 = new SaveFileDialog();
                SaveFD1.FileName = "";
                SaveFD1.InitialDirectory = "C";
                SaveFD1.Title = "save file Name";
                SaveFD1.Filter = "JPG|*.jpg|Bmp|*.bmp";
                 if (SaveFD1.ShowDialog() == DialogResult.OK)
                {
                    
                    System.IO.Stream filename = (System.IO.FileStream)SaveFD1.OpenFile();
                    int r = SaveFD1.FileName.Length;
                    for (int r1 = 0; r1<=r;)
                    {
                        if (SaveFD1.FileName[r1] != '.')
                            r1++;
                        else
                        {
                            r = r1;
                            break;
                        }
                    }
                    
                       if (SaveFD1.FileName[++r] == 'j')
                        {
                            using (Graphics g = Graphics.FromImage(bac))
                        {
                           g.DrawImage(mybitmap, 0, 0);
                        }
                        bac.Save(filename, ImageFormat.Jpeg);
                        }
                        else if (SaveFD1.FileName[r] == 'b')
                        {
                            using (Graphics g = Graphics.FromImage(bac))
                            {
                                g.DrawImage(mybitmap, 0, 0);
                            }
                            bac.Save(filename, ImageFormat.Jpeg);
                        }
                        else
                        {
                            using (Graphics g = Graphics.FromImage(bac))
                            {
                                g.DrawImage(mybitmap, 0, 0);
                            }
                            bac.Save(filename, ImageFormat.Png);
                        }
                    
                    filename.Close();
                }
            }
        }

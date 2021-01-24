    private void SetUpPuzzle(int parts)
            {
                // Comment ***********
                //Panel P = new Panel
                //{
                //    Size = new Size(200, 200),
                //    Location = new Point(394, 62),
                //};
    
                //Controls.Add(P);
                //Control board = P;     ***********
                int total = parts * parts;
                var PB = new PictureBox[total];
                var imgarray = new Image[total];
                var img = User_Image.Image;
                int W =Convert.ToInt32(img.Width / Math.Sqrt(parts));
                int H = Convert.ToInt32(img.Height / Math.Sqrt(parts));
                int size = Convert.ToInt32(200 / Math.Sqrt(parts));
    
                for (int x = 0; x < parts; x++)
                {
                    for (int y = 0; y < parts; y++)
                    {
                        var index = x * parts + y;
    
                        imgarray[index] = new Bitmap(W, H);
                        using (Graphics graphics = Graphics.FromImage(imgarray[index]))
                            graphics.DrawImage(img, new Rectangle(0, 0, W, H),
                                               new Rectangle(x * W, y * H, W, H), GraphicsUnit.Pixel);
    
                        PB[index] = new PictureBox
                        {
                            Name = "P" + index,
                            Size = new Size(size, size),
                            Location = new Point(x * size, y * size),
                            Image = imgarray[index],
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };
    
                        PB[index].MouseEnter += Form1_MouseEnter; 
                        PB[index].MouseLeave += Form1_MouseLeave; 
                        PB[index].MouseClick += Form1_MouseClick; 
                        //Comment                         
                        //PB[index].Dispose();       < -----------------
                        // Add PB in Panel in form
                        panel1.Controls.Add(PB[index]);
                       
                       
                    }
                }
                // after add all refresh panel
                panel1.Refresh();
            }
            private void Form1_MouseClick(object sender, MouseEventArgs e)
            {
                throw new NotImplementedException();
            }
    
            private void Form1_MouseLeave(object sender, EventArgs e)
            {
                throw new NotImplementedException();
            }
    
            private void Form1_MouseEnter(object sender, EventArgs e)
            {
                throw new NotImplementedException();
            }

     System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(100, 100);
                for (int x=0;x<= bmp.Width;x++)
                {
                    //just an example, you will have to use the actual color values
                    System.Drawing.Color myBorderColor = System.Drawing.Color.Gray;
                    for (int y = 0; y <= bmp.Width; y++)
                    {
                        var pixel = bmp.GetPixel(x, y);
                        if (pixel!= myBorderColor)
                        {
                            //we have hit something that is not your border, record it.
                            //so just mark down in a list or whatever where the grey is vs not
                        }
                    }
                }

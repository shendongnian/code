            threshold3 = threshold *3;
            int height = tempBmp.Height;
            int width = bmpData.Width * 4;
            Parallel.For(0, height, y =>
            {
                byte* offset = ptr + (y * bmpData.Stride); //set row
                for (int x = 0; x < width; x = x + 4)
                {
                    //changing pixel value 
                    int v = (offset[x] + offset[x + 1] + offset[x + 2]) > threshold3 ? 
                            Byte.MaxValue : Byte.MinValue;;
                    offset[x] = v ;
                    offset[x+1] = v;
                    offset[x+2] = v;
                    offset[x+3] = 255;
                }
            });

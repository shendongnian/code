        void Test()
        {
            Bitmap bmp = new Bitmap(50, 50);//you will load it from file or resource
            Color c = Color.Green;//transparent color
            //loop height and width. 
            // YOU MAY HAVE TO CONVERT IT TO Height X VerticalResolution and
            // Width X HorizontalResolution
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    var p = bmp.GetPixel(j, i);//get pixle at point
                    //if pixle color not equals transparent
                    if(!c.Equals(Color.FromArgb(p.ToArgb())))
                    {
                        //set it to white
                        bmp.SetPixel(j,i,Color.White);
                    }
                }
            }
        }

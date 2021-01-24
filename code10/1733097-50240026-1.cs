    private void button_Click(object sender, EventArgs e)
    {
        GrayScaleFirst();
        BernsenThreshold();
        int xc, yc;
        if(GetBlackPixelCenter(out xc, out yc))
        {
             // use xc, yc
        }
    }
    void GrayScaleFirst()
    {
        /////////////Gray Scale First////////////////////
        byte grayscale;
        Bitmap image=new Bitmap(pictureBox1.Image);            
        if(image==null)
        {
            return;
        }
        for(int y=0; y<image.Height; y++)
        {
            for(int x=0; x<image.Width; x++)
            {
                Color color=image.GetPixel(x, y);
                grayscale=Convert.ToByte((color.R+color.G+color.B)/3);
                image.SetPixel(x, y, Color.FromArgb(grayscale, grayscale, grayscale));
            }
        }
        pictureBox1.Image=image;
            
    }
    void BernsenThreshold()
    {
        Bitmap gray=pictureBox1.Image as Bitmap;
        Bitmap image=new Bitmap(pictureBox1.Image);
        int iMin, iMax, t, c, contrastThreshold, pixel;
        contrastThreshold=110;
        for(int y=0; y<image.Height; y++)
        {
            for(int x=0; x<image.Width; x++)
            {
                Color color=gray.GetPixel(x, y);
                pixel=color.R;
                var list=GetNeighboursSorted(x, y, image);
                iMin=list[0];
                iMax=list[list.Count-1];
                t=((iMax+iMin)/2);
                c=(iMax-iMin);
                if(c<contrastThreshold)
                {
                    pixel=((t>=160)?0:255);
                }
                else
                {
                    pixel=((pixel>=t)?0:255);
                }
                image.SetPixel(x, y, Color.FromArgb(pixel, pixel, pixel));
            }
        }
        pictureBox1.Image=image;
            
    }
    bool GetBlackPixelCenter(out int x_center, out int y_center)
    {
        Bitmap image=pictureBox1.Image as Bitmap;
        int black=Color.Black.ToArgb();
        x_center=0; y_center=0;
        int count = 0;
        for(int h=0; h<image.Height; h++)
        {
            for(int w=0; w<image.Width; w++)
            {
                //Get the color at each pixel
                Color now_color=image.GetPixel(w, h);
                //Compare Pixel's Color ARGB property with the picked color's ARGB Property 
                if(now_color.ToArgb()==black)
                {
                    x_center+=w;
                    y_center+=h;
                    count++;
                }
            }
        }
        x_center=count>0?x_center/count:0;
        y_center=count>0?y_center/count:0;
        return count>0;
    }
    static List<byte> GetNeighboursSorted(int x, int y, Bitmap image)
    {
        var list=new List<byte>();
        int i1=Math.Max(0, y-1), i2=Math.Min(y+1, image.Height-1);
        int j1=Math.Max(0, x-1), j2=Math.Min(x+1, image.Width-1);
        for(int i=i1; i<=i2; i++)
        {
            for(int j=j1; j<=j2; j++)
            {
                if(i!=y && j!=x) 
                {
                    list.Add( Convert.ToByte(image.GetPixel(j, i).GetBrightness()*255));
                }
            }
        }
        list.Sort();
        return list;
    }

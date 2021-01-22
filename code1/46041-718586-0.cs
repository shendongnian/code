    // Changed loops to declare the variable, for stylistic purposes
    for (int iy = 0; iy < h; iy++)
    {
        // Changed here - cast camera.fov_y
        double angy = ((double) camera.fov_y / h) * iy;
        for (int ix = 0; ix < w; ix++)
        {
            // Changed here - cast camera.fov_x
            double angx = ((double) camera.fov_x / w) * ix;
            //output[ix,iy].r = (int)Math.Round(255 * (angy / camera.fov_y);
            //output[ix,iy].b = (int)Math.Round(255 * (angy / camera.fov_y); 
            double tr = (angx / camera.fov_x) * 255D;
            double tb = (angy / camera.fov_y) * 255D;
            Console.Write("({0},{1})", Math.Round(tr), Math.Round(tb));
            output.SetPixel(ix, iy, Color.FromArgb(Convert.ToInt32(tr), 
                                                   0,
                                                   Convert.ToInt32(tb)) );
            Console.Write(".");
        }
        Console.WriteLine();
    }

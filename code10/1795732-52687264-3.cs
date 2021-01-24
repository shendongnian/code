    extern "C"
    {
        void ProcessImage(unsigned char* raw, int width, int height);
    }
    ...
    
    void ProcessImage(unsigned char* raw, int width, int height)
    {
        for(int y=0; y < height; y++)
        {
            for(int x=0; x < width; x++)
            {
                unsigned char* pixel = raw + (y * width * 4 + x * 4);
                pixel[0] = pixel[0]-(unsigned char)2; //R
                pixel[1] = pixel[1]-(unsigned char)2; //G
                pixel[2] = pixel[2]-(unsigned char)2; //B
                pixel[3] = pixel[3]-(unsigned char)2; //Alpha
            }
        }
    }

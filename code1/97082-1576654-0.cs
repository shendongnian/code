    public static Size getScaledDimensions( Image img, Int32 maxW, Int32 maxH)
    {
        //check if image is already within desired dimensions
        if (img.Height <= maxH & img.Width <= maxW)
        {
            Size orgsize = new Size(img.Width, img.Height);
            return orgsize; // no need to rescale
        }
        else //proceed with rescaling
        {
           
            int finalH;
            int finalW;
            //use height/width ratio to determine our new dimensions
            double hwRatio = (double)img.Height / (double)img.Width;
            
            
                 int newW = (int) (h/ ratio);
                int newH = (int) (ratio * w);
               //make sure we scale the right dimension
                if (newW <= maxW) // scale width
                {
                    finalH = maxH;
                    finalW = newW;
                }
                else
                { // scale height
                    finalH = newH;
                    finalW = maxW;
                }//end if
            Size newsize = new Size(finalW, finalH);
            
            return newsize;
        }

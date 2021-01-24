    public uint FrameRate(VideoEncodingProperties properties)
    {
        get
        {
            if (properties is VideoEncodingProperties)
            {
                if ((properties as VideoEncodingProperties).FrameRate.Denominator != 0)
                {
                    return (properties as VideoEncodingProperties).FrameRate.Numerator /
                        (properties as VideoEncodingProperties).FrameRate.Denominator;
                }
            }
    
            return 0;
        }
    }
       
 
        

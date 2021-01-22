    void foo( IImage image )
    {
        if ( image is Image<Bgr, Byte> )
        {
            ((Image<Bgr, Byte>)(image)).Draw();
        }
        // handle the other types the same way.
    }

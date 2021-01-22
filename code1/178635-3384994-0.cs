    Bitmap ImageA...
    Bitmap ImageB...
    for ( Int64 x = 0; x < ImageA.Width; x++ )
    {
         for ( Int64 y = 0; y < ImageA.Height; y++ )
         {
             if ( ImageA.GetPixel(x, y) != ImageB.GetPixel(x, y) )
             {
                return false;
             }
         }
    }

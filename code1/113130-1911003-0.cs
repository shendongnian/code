    public static class BitmapExtensions
    {
        /// <summary>
        /// See if bmp is contained in template with a small margin of error.
        /// </summary>
        /// <param name="template">The Bitmap that might contain.</param>
        /// <param name="bmp">The Bitmap that might be contained in.</param>        
        /// <returns>You guess!</returns>
        public static bool Contains(this Bitmap template, Bitmap bmp)
        {
            const Int32 divisor = 4;
            const Int32 epsilon = 10;
    
            ExhaustiveTemplateMatching etm = new ExhaustiveTemplateMatching(0.9f);                      
    
            TemplateMatch[] tm = etm.ProcessImage(
                new ResizeNearestNeighbor(template.Width / divisor, template.Height / divisor).Apply(template),
                new ResizeNearestNeighbor(bmp.Width / divisor, bmp.Height / divisor).Apply(bmp)
                );
    
            if (tm.Length == 1)
            {
                Rectangle tempRect = tm[0].Rectangle;
    
                if (Math.Abs(bmp.Width / divisor - tempRect.Width) < epsilon
                    &&
                    Math.Abs(bmp.Height / divisor - tempRect.Height) < epsilon)
                {
                    return true;
                }                
            }
    
            return false;
        }
    }

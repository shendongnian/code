    private bool ImageCompareArray(Bitmap firstImage, Bitmap secondImage)
            {
                bool flag = true;
                string firstPixel;
                string secondPixel;
             
                if (firstImage.Width == secondImage.Width 
                    && firstImage.Height == secondImage.Height)
                {
                    for (int i = 0; i<firstImage.Width; i++)
                    {
                        for (int j = 0; j<firstImage.Height; j++)
                        {
                       firstPixel = firstImage.GetPixel(i, j).ToString();
                       secondPixel = secondImage.GetPixel(i, j).ToString();
                       if (firstPixel != secondPixel)
                       {
                           flag = false;
                           break;
                       }
                   }
               }
        
               if (flag == false)
               {
                   return false;
               }
               else
               {
                   return true;
               }
           }
           else
           {
               return false;
           }
       }

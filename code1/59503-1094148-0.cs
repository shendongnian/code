      private void drawAndShadeTheImage(Graphics g)
      {
         //if the image is null then there is nothing to do.
         if (Image != null)
         {
            Bitmap bitMap = new Bitmap(Image);
            //if this control is selected, shade the image to allow the user to
            //visual identify what is selected.
            if (ContainsFocus)
            {               
               //The delta is the percentage of change in color shading of 
               //the image.
               int delta = 70;
               //zero is the lowest value (0 - 255) that can be represented by
               //a color component.
               int zero = 0;
               //Get each pixel in the image and shade it.
               for (int y = 0; y < bitMap.Height; y++)
               {
                  for (int x = 0; x < bitMap.Width; x++)
                  {
                     Color oColor = bitMap.GetPixel(x, y);
                     //Lime is the background color on the image and should
                     //always be transparent, if this check is removed the
                     //background will be displayed.
                     if (oColor.ToArgb() != Color.Lime.ToArgb())
                     {
                        int oR = oColor.R - delta < zero ? zero : 
                           oColor.R - delta;
                        int oG = oColor.G - delta < zero ? zero : 
                           oColor.G - delta;
                        int oB = oColor.B - delta < zero ? zero : 
                           oColor.B - delta;
                        int oA = oColor.A - delta < zero ? zero : 
                           oColor.A - delta;
                        Color nColor = Color.FromArgb(oA, oR, oG, oB);
                        bitMap.SetPixel(x, y, nColor);
                     }
                  }
               }
            }
            //Make the background of the image transparent.
            bitMap.MakeTransparent();
                        
            g.DrawImage(bitMap, this.ClientRectangle);            
         }
      }

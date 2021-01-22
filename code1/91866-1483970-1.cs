    double GetRGBAverageForPixelRange( int istartRange, int iEndRange,  Bitmap oBitmap )
    		{
    			double dRetnVal = 0 ;
    			Color oTempColor ; 
    			int i, j ;
    			for( int iCounter = istartRange ; iCounter < iEndRange ; iCounter++ )
    			{
    				i = (iCounter % (oBitmap.Width));
    				j = ( iCounter / ( oBitmap.Width ) ) ;
    				if (i >= 0 && j >= 0 && i < oBitmap.Width && j < oBitmap.Height )
    				{
    					oTempColor = oBitmap.GetPixel(i, j);
    					dRetnVal = dRetnVal + oTempColor.ToArgb();
    				}
    
    			}
    			return dRetnVal ;
    		}

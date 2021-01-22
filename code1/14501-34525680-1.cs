    public static class ExtensionMethods 
    {
         public static string[] get1Dim(this string[,] RectArr, int _1DimIndex , int _2DimIndex   )
         {
            string[] temp = new string[RectArr.GetLength(1)];
            if (_2DimIndex == -1)
	        {
              for (int i = 0; i < RectArr.GetLength(1); i++)
              {   temp[i] = RectArr[_1DimIndex, i];    }
            }
            else
            {
              for (int i = 0; i < RectArr.GetLength(0); i++)
              {   temp[i] = RectArr[  i , _2DimIndex];    }
            }
         
             return temp;
          }
    }

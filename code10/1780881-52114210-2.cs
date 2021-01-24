           const string FILENAME = @"c:\temp\test.jpg";
            public Form1()
            {
                InitializeComponent();
                Bitmap image = new Bitmap(FILENAME);
                
                int height = (int)image.Height ;
                int width = (int)image.Width;
                
                List<List<List<Color>>> bytes = new List<List<List<Color>>>();
                List<List<List<Int32>>> grayscale_map_int = new List<List<List<Int32>>>();
                for (int row = 0; row < height; row += 4)
                {
                    for (int col = 0; col < width; col += 4)
                    {
                        bytes.Add(new List<List<Color>>()  { 
                             new List<Color>() { image.GetPixel(col, row), image.GetPixel(col + 1, row), image.GetPixel(col + 2, row), image.GetPixel(col + 3, row)} , 
                             new List<Color>() { image.GetPixel(col, row + 1), image.GetPixel(col + 1, row + 1), image.GetPixel(col + 2, row + 1), image.GetPixel(col + 3, row + 1)} , 
                             new List<Color>() { image.GetPixel(col, row + 2), image.GetPixel(col + 1, row + 2), image.GetPixel(col + 2, row + 2), image.GetPixel(col + 3, row + 2)} , 
                             new List<Color>() { image.GetPixel(col, row + 3), image.GetPixel(col + 1, row + 3), image.GetPixel(col + 2, row + 3), image.GetPixel(col + 3, row + 3)} , 
                        });
                        grayscale_map_int.Add(new List<List<Int32>>()  { 
                             new List<Int32>() { GetGrayScale(image.GetPixel(col, row)), GetGrayScale(image.GetPixel(col + 1, row)), GetGrayScale(image.GetPixel(col + 2, row)), GetGrayScale(image.GetPixel(col + 3, row))} , 
                             new List<Int32>() { GetGrayScale(image.GetPixel(col, row + 1)), GetGrayScale(image.GetPixel(col + 1, row + 1)), GetGrayScale(image.GetPixel(col + 2, row + 1)), GetGrayScale(image.GetPixel(col + 3, row + 1))} , 
                             new List<Int32>() { GetGrayScale(image.GetPixel(col, row + 2)), GetGrayScale(image.GetPixel(col + 1, row + 2)), GetGrayScale(image.GetPixel(col + 2, row + 2)), GetGrayScale(image.GetPixel(col + 3, row + 2))} , 
                             new List<Int32>() { GetGrayScale(image.GetPixel(col, row + 3)), GetGrayScale(image.GetPixel(col + 1, row + 3)), GetGrayScale(image.GetPixel(col + 2, row + 3)), GetGrayScale(image.GetPixel(col + 3, row + 3))} , 
                        });
      
                    }
                } 
                
            }
            public Int32 GetGrayScale(Color color)
            {
                return Convert.ToInt32(0.2126 * color.R + 0.7152 * color.G + 0.0722 * color.B);
            }

    	public class ImageProcessing{
    	private int[,] pixelArray;
    	private int imageWidth;
    	private int imageHeight;
    	List<MyColor> colors;
    	public void BuildPixelArray(ref Image myImage)
    	{
    		imageHeight = myImage.Height;
    		imageWidth = myImage.Width;
    		pixelArray = new int[imageWidth, imageHeight];
    		Rectangle rect = new Rectangle(0, 0, myImage.Width, myImage.Height);
    		Bitmap temp = new Bitmap(myImage);
    		BitmapData bmpData = temp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
    		int remain = bmpData.Stride - bmpData.Width * 3;
    		unsafe
    		{
    			byte* ptr = (byte*)bmpData.Scan0;
    			for (int j = 15; j < bmpData.Height; j++)
    			{
    				for (int i = 0; i < bmpData.Width; i++)
    				{
    					pixelArray[i, j] = ptr[0] + ptr[1] * 256 + ptr[2] * 256 * 256;
    					ptr += 3;
    				}
    				ptr += remain;
    			}
    		}
    		temp.UnlockBits(bmpData);
    	}
    
    	public void FindRegions()
    	{
    		colors = new List<MyColor>();
    
    		for (int i = 0; i < imageWidth; i++)
    		{
    			for (int j = 0; j < imageHeight; j++)
    			{
    				int tmpColorValue = pixelArray[i, j];
    				MyColor tmp = new MyColor(tmpColorValue);
    				if (colors.Contains(tmp))
    				{
    					MyColor tmpColor = (from p in colors
    										where p.colorValue == tmpColorValue
    										select p).First();
    
    					tmpColor.pointList.Add(new MyPoint(i, j));
    				}
    				else
    				{
    					tmp.pointList.Add(new MyPoint(i, j));
    					colors.Add(tmp);
    				}
    			}
    		}
    	}
    }
    public class MyColor : IEquatable<MyColor>
    {
        public int colorValue { get; set; }
        public List<MyPoint> pointList = new List<MyPoint>();
        public MyColor(int _colorValue)
        {
            colorValue = _colorValue;
        }
        public bool Equals(MyColor other)
        {
            if (this.colorValue == other.colorValue)
            {
                return true;
            }
            return false;
        }
    }
    public class MyPoint
    {
        public int xCoord { get; set; }
        public int yCoord { get; set; }
    
        public MyPoint(int _xCoord, int _yCoord)
        {
            xCoord = _xCoord;
            yCoord = _yCoord;
        }
    }

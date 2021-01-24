        public static bool ImageCompareString(Bitmap firstImage, Bitmap secondImage)
    {
		try
		{
			MemoryStream ms = new MemoryStream();
			firstImage.Save(ms, ImageFormat.Png);
			string firstBitmap = Convert.ToBase64String(ms.ToArray());
			ms.Position = 0;
			secondImage.Save(ms, ImageFormat.Png);
			string secondBitmap = Convert.ToBase64String(ms.ToArray());
			if (firstBitmap.Equals(secondBitmap))
			{
				return true;
			}
			else 
			{           
				return false;
			}
		} 
		catch(Exception ex)
		{
			//log it, display or whatever
		} 
		finnaly 
		{
			ms.Close();
			ms.Dispose();
		}
    }

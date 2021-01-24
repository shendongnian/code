	public byte[] iOSBundleResourceByNameToByteArray(string fileName)
	{
		using (var image = UIImage.FromFile(fileName))
		using (NSData imageData = image.AsPNG())
		{
			var byteArray = new byte[imageData.Length];
			System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, byteArray, 0, Convert.ToInt32(imageData.Length));
			return byteArray;
		}
	}

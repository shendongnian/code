	public byte[] DrawableByNameToByteArray(string fileName)
	{
		var context = Application.Context;
		using (var drawable = Xamarin.Forms.Platform.Android.ResourceManager.GetDrawable(context, fileName))
		using (var bitmap = ((BitmapDrawable)drawable).Bitmap)
		{
			var stream = new MemoryStream();
			bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);
			bitmap.Recycle();
			return stream.ToArray();
		}
	}

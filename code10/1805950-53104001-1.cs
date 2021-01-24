	public static bool ImportImage(string imageFile, string newFilePah, string oldDicomFile)
	{
		Bitmap bitmap = new Bitmap(imageFile);
		int rows, columns;
		byte[] pixels = GetPixels(bitmap, out rows, out columns);
		MemoryByteBuffer buffer = new MemoryByteBuffer(pixels);
		DicomDataset dataset = new DicomDataset();
		var dicomfile = DicomFile.Open(oldDicomFile);
		dataset = dicomfile.Dataset.Clone();
		dataset.AddOrUpdate(DicomTag.PhotometricInterpretation, PhotometricInterpretation.Rgb.Value);
		dataset.AddOrUpdate(DicomTag.Rows, (ushort)rows);
		dataset.AddOrUpdate(DicomTag.Columns, (ushort)columns);
		dataset.AddOrUpdate(DicomTag.BitsAllocated, (ushort)8);
		DicomPixelData pixelData = DicomPixelData.Create(dataset, true);
		pixelData.BitsStored = 8;
		pixelData.SamplesPerPixel = 3;
		pixelData.HighBit = 7;
		pixelData.PhotometricInterpretation = PhotometricInterpretation.Rgb;
		pixelData.PixelRepresentation = 0;
		pixelData.PlanarConfiguration = 0;
		pixelData.Height = (ushort)rows;
		pixelData.Width = (ushort)columns;
		pixelData.AddFrame(buffer);
		dicomfile = new DicomFile(dataset);
		dicomfile.Save(newFilePah);
		return true;
	}
	private static byte[] GetPixels(Bitmap bitmap, out int rows, out int columns)
	{
		using(var stream = new MemoryStream())
		{
			bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
			rows = bitmap.Height;
			columns = bitmap.Width;
			return stream.ToArray();
		}
	}

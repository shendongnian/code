	public Stream MatToStream(Mat mat)
	{
		using (var vect = new MatOfByte())
		{
			if (Imgcodecs.Imencode(".png", mat, vect))
				return new MemoryStream(vect.ToArray());
			return Stream.Null;
		}
	}

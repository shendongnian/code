        // RTF Image Format
		// {\pict\wmetafile8\picw[A]\pich[B]\picwgoal[C]\pichgoal[D]
		//  
		// A	= (Image Width in Pixels / Graphics.DpiX) * 2540 
		//  
		// B	= (Image Height in Pixels / Graphics.DpiX) * 2540 
		//  
		// C	= (Image Width in Pixels / Graphics.DpiX) * 1440 
		//  
		// D	= (Image Height in Pixels / Graphics.DpiX) * 1440 
		
		[Flags]
		enum EmfToWmfBitsFlags
		{
			EmfToWmfBitsFlagsDefault = 0x00000000,
			EmfToWmfBitsFlagsEmbedEmf = 0x00000001,
			EmfToWmfBitsFlagsIncludePlaceable = 0x00000002,
			EmfToWmfBitsFlagsNoXORClip = 0x00000004
		}
		const int MM_ISOTROPIC = 7;
		const int MM_ANISOTROPIC = 8;
		[DllImport("gdiplus.dll")]
		private static extern uint GdipEmfToWmfBits(IntPtr _hEmf, uint _bufferSize,
			byte[] _buffer, int _mappingMode, EmfToWmfBitsFlags _flags);
		[DllImport("gdi32.dll")]
		private static extern IntPtr SetMetaFileBitsEx(uint _bufferSize,
			byte[] _buffer);
		[DllImport("gdi32.dll")]
		private static extern IntPtr CopyMetaFile(IntPtr hWmf,
			string filename);
		[DllImport("gdi32.dll")]
		private static extern bool DeleteMetaFile(IntPtr hWmf);
		[DllImport("gdi32.dll")]
		private static extern bool DeleteEnhMetaFile(IntPtr hEmf);
        	public static string GetEmbedImageString(Bitmap image)
        	{
            		Metafile metafile = null;
            		float dpiX; float dpiY;
            		
            		using (Graphics g = Graphics.FromImage (image)) 
            		{
                		IntPtr hDC = g.GetHdc ();
                		metafile = new Metafile (hDC, EmfType.EmfOnly);
                		g.ReleaseHdc (hDC);
            		}
            		using (Graphics g = Graphics.FromImage (metafile)) 
            		{
                		g.DrawImage (image, 0, 0);
				dpiX = g.DpiX;
				dpiY = g.DpiY;
            		}
            		
            		IntPtr _hEmf = metafile.GetHenhmetafile ();
            		uint _bufferSize = GdipEmfToWmfBits (_hEmf, 0, null, MM_ANISOTROPIC,
                	EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);
            		byte[] _buffer = new byte[_bufferSize];
            		GdipEmfToWmfBits (_hEmf, _bufferSize, _buffer, MM_ANISOTROPIC,
                    							EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);
            		IntPtr hmf = SetMetaFileBitsEx (_bufferSize, _buffer);
            		string tempfile = Path.GetTempFileName ();
            		CopyMetaFile (hmf, tempfile);
            		DeleteMetaFile (hmf);
            		DeleteEnhMetaFile (_hEmf);
            		var stream = new MemoryStream ();
            		byte[] data = File.ReadAllBytes (tempfile);
            		//File.Delete (tempfile);
            		int count = data.Length;
            		stream.Write (data, 0, count);
            		
            		string proto = @"{\rtf1{\pict\wmetafile8\picw" + (int)( ( (float)image.Width / dpiX ) * 2540 )
			                          + @"\pich" + (int)( ( (float)image.Height / dpiY ) * 2540 )
			                          + @"\picwgoal" + (int)( ( (float)image.Width / dpiX ) * 1440 )
			                          + @"\pichgoal" + (int)( ( (float)image.Height / dpiY ) * 1440 )
			                          + " " 
						  + BitConverter.ToString(stream.ToArray()).Replace("-", "")
			                          + "}}";           		
            		return proto;
        	}

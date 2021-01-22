	// Based on: http://www.codeproject.com/KB/cs/IconExtractor.aspx
	// And a hint from: http://www.codeproject.com/KB/cs/IconLib.aspx
	
	Bitmap ExtractVistaIcon(Icon icoIcon)
	{
		Bitmap bmpPngExtracted = null;
		try
		{
			byte[] srcBuf = null;
			using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
				{ icoIcon.Save(stream); srcBuf = stream.ToArray(); }
			const int SizeICONDIR = 6;
			const int SizeICONDIRENTRY = 16;
			int iCount = BitConverter.ToInt16(srcBuf, 4);
			for (int iIndex=0; iIndex<iCount; iIndex++)
			{
				int iWidth	= srcBuf[SizeICONDIR + SizeICONDIRENTRY * iIndex];
				int iHeight	= srcBuf[SizeICONDIR + SizeICONDIRENTRY * iIndex + 1];
				int iBitCount	= BitConverter.ToInt16(srcBuf, SizeICONDIR + SizeICONDIRENTRY * iIndex + 6);
				if (iWidth == 0 && iHeight == 0 && iBitCount == 32)
				{
					int iImageSize   = BitConverter.ToInt32(srcBuf, SizeICONDIR + SizeICONDIRENTRY * iIndex + 8);
					int iImageOffset = BitConverter.ToInt32(srcBuf, SizeICONDIR + SizeICONDIRENTRY * iIndex + 12);
					System.IO.MemoryStream destStream = new System.IO.MemoryStream();
					System.IO.BinaryWriter writer = new System.IO.BinaryWriter(destStream);
					writer.Write(srcBuf, iImageOffset, iImageSize);
					destStream.Seek(0, System.IO.SeekOrigin.Begin);
					bmpPngExtracted = new Bitmap(destStream); // This is PNG! :)
					break;
				}
			}
		}
		catch { return null; }
		return bmpPngExtracted;
	}

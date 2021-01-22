		// Stream a binary file to the user's web browser so they can open or save it.
		public static void SendAsFileToBrowser(byte[] File, string Type, string FileName)
		{
			string disp = "attachment";
			if (string.IsNullOrEmpty(FileName))
			{
				disp = "inline";
			}
			// set headers
			var r = HttpContext.Current.Response;
			r.ContentType = Type; // eg "image/Png"
			r.Clear();
			r.AddHeader("Content-Type", "binary/octet-stream");
			r.AddHeader("Content-Length", File.Length.ToString());
			r.AddHeader("Content-Disposition", disp + "; filename=" + FileName + "; size=" + File.Length.ToString());
			r.Flush();
			// write data to requesting browser
			r.BinaryWrite(File);
			r.Flush();
		}
		//overload
		public static void SendAsFileToBrowser(byte[] File, string Type)
		{
			SendAsFileToBrowser(File, Type, "");
		}
		// overload
		public static void SendAsFileToBrowser(System.IO.Stream File, string Type, string FileName)
		{
			byte[] buffer = new byte[File.Length];
			int length = (int)File.Length;
			File.Write(buffer, 0, length - 1);
			SendAsFileToBrowser(buffer, FileName, Type);
		}

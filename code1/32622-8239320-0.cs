			SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();
			
			//specify some options
			r.OutputFormat = SautinSoft.RtfToHtml.eOutputFormat.XHTML_10;
			r.Encoding = SautinSoft.RtfToHtml.eEncoding.UTF_8;
            string rtfFile = @"d:\test.rtf";
			string htmlFile = @"d:\test.html";
			string rtfString = null;
			ReadFromFile(rtfFile,ref rtfString);
         
			int i = r.ConvertStringToFile(rtfString,htmlFile);
            if (i == 0)
			{
				System.Console.WriteLine("Converted successfully!");
				System.Diagnostics.Process.Start(htmlFile);
			}
			else
				System.Console.WriteLine("Converting Error!");
		}
		public static int ReadFromFile(string fileName,ref string fileStr)
		{
			try
			{
				FileInfo fi = new FileInfo(fileName);
				StreamReader strmRead = fi.OpenText();
				fileStr = strmRead.ReadToEnd();
				strmRead.Close();
				return 0;
			}
			catch 
			{
				//error open file
				System.Console.WriteLine("Error in open file");
				return 1;
			}
		}

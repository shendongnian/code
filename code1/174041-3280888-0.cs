    public static RenderTargetBitmap ConvertToBitmap(UIElement uiElement, double resolution)
                {
                    var scale = resolution / 96d;
                    uiElement.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
                    var sz = uiElement.DesiredSize;
                    var rect = new Rect(sz);
                    uiElement.Arrange(rect);
                    var bmp = new RenderTargetBitmap((int)(scale * (rect.Width)), (int)(scale * (rect.Height)), scale * 96, scale * 96, PixelFormats.Default);
                    bmp.Render(uiElement);
                    return bmp;
                }
        
        public static string CreatePDF(RenderTargetBitmap bitmap)
        		{
        			var jpegString = GridImageConverter.CreateJpeg(bitmap);
        			var stringBuilder = new StringBuilder();
        			stringBuilder.AppendFormat(
        				@"%PDF-1.4
        %");
        			stringBuilder.AppendFormat("\u00e2\u00e3\u00cf\u00d3\n");
        			stringBuilder.AppendFormat(@"1 0 obj
        <</Type/Catalog/Pages 2 0 R>>
        endobj
        2 0 obj
        <</Type/Pages/Kids[3 0 R]/Count 1>>
        endobj
        3 0 obj
        <</Type/Page/Parent 2 0 R/MediaBox[0 0 {0} {1}]/Contents 4 0 R/Resources<</XObject<</Im0 5 0 R>>>>>>
        endobj
        ", (int)(bitmap.Width * 0.75), (int)(bitmap.Height * 0.75));
        			int obj4Offset = stringBuilder.Length;
        			stringBuilder.AppendFormat(
        				@"4 0 obj
        <</Length 27>>stream
        {0} 0 0 {1} 0 0 cm
        /Im0 Do
        endstream
        endobj
        ", (int)(bitmap.Width * 0.75), (int)(bitmap.Height * 0.75));
        			int obj5Offset = stringBuilder.Length;
        			stringBuilder.AppendFormat(
        				@"5 0 obj
        <</Length {2}/Filter/DCTDecode/Type/XObject/Subtype/Image/Width {0}/Height {1}/ColorSpace/DeviceRGB/BitsPerComponent 8>>stream
        {3}
        endstream
        endobj
        ", bitmap.PixelWidth, bitmap.PixelHeight, jpegString.Length, jpegString);
        			int xrefOffset = stringBuilder.Length;
        			stringBuilder.AppendFormat(
        				@"xref
        1 5
        0000000015 00000 n
        0000000064 00000 n
        0000000118 00000 n
        0000000{0} 00000 n
        0000000{1} 00000 n
        trailer
        <</Size 6/Root 1 0 R>>
        startxref
        {2}
        %%EOF
        ", obj4Offset, obj5Offset, xrefOffset);
        
        			return stringBuilder.ToString();
        		}
        
        		public static void SaveToPDF(UIElement uiElement, string filePath, double resolution)
        		{
        			SaveToPDF(ConvertToBitmap(uiElement, resolution), filePath);
        		}
        
        		public static void SaveToPDF(RenderTargetBitmap bmp, string filePath)
        		{
        			if (filePath != null)
        			{
        				try
        				{
        					using (var fileStream = File.Create(filePath))
        					{
        						using (var streamWriter = new StreamWriter(fileStream, Encoding.Default))
        						{
        							streamWriter.Write(CreatePDF(bmp));
        							streamWriter.Close();
        						}
        						fileStream.Close();
        					}
        				}
        				catch(Exception ex)
        				{
        					//handle exception here
        				}
        			}
        		}

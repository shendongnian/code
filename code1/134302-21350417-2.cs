	    private byte[] AddWatermark(byte[] bytes, BaseFont bf)
	    {
			using(var ms = new MemoryStream(10 * 1024))
			{
				using(var reader = new PdfReader(bytes))
				using(var stamper = new PdfStamper(reader, ms))
				{
					int times = reader.NumberOfPages;
					for (int i = 1; i <= times; i++)
					{
						var dc = stamper.GetOverContent(i);
						PdfHelper.AddWaterMark(dc, AppName, bf, 48, 35, new BaseColor(70, 70, 255), reader.GetPageSizeWithRotation(i));
					}
					stamper.Close();
				}
				return ms.ToArray();
			}
	    }
		public static void AddWaterMark(PdfContentByte dc, string text, BaseFont font, float fontSize, float angle, BaseColor color, Rectangle realPageSize, Rectangle rect = null)
		{
			var gstate = new PdfGState { FillOpacity = 0.1f, StrokeOpacity = 0.3f };
			dc.SaveState();
			dc.SetGState(gstate);
			dc.SetColorFill(color);
			dc.BeginText();
			dc.SetFontAndSize(font, fontSize);
			var ps = rect ?? realPageSize; /*dc.PdfDocument.PageSize is not always correct*/
			var x = (ps.Right + ps.Left) / 2;
			var y = (ps.Bottom + ps.Top) / 2;
			dc.ShowTextAligned(Element.ALIGN_CENTER, text, x, y, angle);
			dc.EndText();
			dc.RestoreState();
		}

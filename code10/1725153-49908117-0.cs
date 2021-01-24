		foreach (var chart in Enumerable.Range(0, 10))
		{
			canvas = new PdfCanvas(page, true);
			imgd = ImageDataFactory.Create((byte[])converter.ConvertTo(data, typeof(byte[])));
			img = new iText.Layout.Element.Image(imgd, left, bottom);
			img.ScaleAbsolute(width, heigth);
			new Canvas(canvas, pdf, pageSize)
				.Add(img);
			//page.Flush(true);
			page = pdf.AddNewPage();
		}

	using System;
	using System.Collections.Generic;
	using System.Text;
	using iTextSharp.text.pdf;
	using iTextSharp.text;
	namespace PDF_Tests
	{
		public class TwoColumnHeaderFooter :PdfPageEventHelper
		{
			// This is the contentbyte object of the writer
			PdfContentByte cb;
			// we will put the final number of pages in a template
			PdfTemplate template;
			// this is the BaseFont we are going to use for the header / footer
			BaseFont bf = null;
			// This keeps track of the creation time
			DateTime PrintTime = DateTime.Now;
			#region Properties
			private string _Title;
			public string Title
			{
				get { return _Title; }
				set { _Title = value; }
			}
			private string _HeaderLeft;
			public string HeaderLeft
			{
				get { return _HeaderLeft; }
				set { _HeaderLeft = value; }
			}
			private string _HeaderRight;
			public string HeaderRight
			{
				get { return _HeaderRight; }
				set { _HeaderRight = value; }
			}
			private Font _HeaderFont;
			public Font HeaderFont
			{
				get { return _HeaderFont; }
				set { _HeaderFont = value; }
			}
			private Font _FooterFont;
			public Font FooterFont
			{
				get { return _FooterFont; }
				set { _FooterFont = value; }
			}
			#endregion
			// we override the onOpenDocument method
			public override void OnOpenDocument(PdfWriter writer, Document document)
			{
				try
				{
					PrintTime = DateTime.Now;
					bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
					cb = writer.DirectContent;
					template = cb.CreateTemplate(50, 50);
				}
				catch (DocumentException de)
				{
				}
				catch (System.IO.IOException ioe)
				{
				}
			}
			public override void OnStartPage(PdfWriter writer, Document document)
			{
				base.OnStartPage(writer, document);
				Rectangle pageSize = document.PageSize;
				if (Title != string.Empty)
				{
					cb.BeginText();
					cb.SetFontAndSize(bf, 15);
					cb.SetRGBColorFill(50, 50, 200);
					cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetTop(40));
					cb.ShowText(Title);
					cb.EndText();
				}
				if (HeaderLeft + HeaderRight != string.Empty)
				{
					PdfPTable HeaderTable = new PdfPTable(2);
					HeaderTable.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
					HeaderTable.TotalWidth = pageSize.Width - 80;
					HeaderTable.SetWidthPercentage(new float[] { 45, 45 }, pageSize);
					PdfPCell HeaderLeftCell = new PdfPCell(new Phrase(8, HeaderLeft, HeaderFont));
					HeaderLeftCell.Padding = 5;
					HeaderLeftCell.PaddingBottom = 8;
					HeaderLeftCell.BorderWidthRight = 0;
					HeaderTable.AddCell(HeaderLeftCell);
					PdfPCell HeaderRightCell = new PdfPCell(new Phrase(8, HeaderRight, HeaderFont));
					HeaderRightCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
					HeaderRightCell.Padding = 5;
					HeaderRightCell.PaddingBottom = 8;
					HeaderRightCell.BorderWidthLeft = 0;
					HeaderTable.AddCell(HeaderRightCell);
					cb.SetRGBColorFill(0, 0, 0);
					HeaderTable.WriteSelectedRows(0, -1, pageSize.GetLeft(40), pageSize.GetTop(50), cb);
				}
			}
			public override void OnEndPage(PdfWriter writer, Document document)
			{
				base.OnEndPage(writer, document);
				int pageN = writer.PageNumber;
				String text = "Page " + pageN + " of ";
				float len = bf.GetWidthPoint(text, 8);
				Rectangle pageSize = document.PageSize;
				cb.SetRGBColorFill(100, 100, 100);
				cb.BeginText();
				cb.SetFontAndSize(bf, 8);
				cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetBottom(30));
				cb.ShowText(text);
				cb.EndText();
				cb.AddTemplate(template, pageSize.GetLeft(40) + len, pageSize.GetBottom(30));
				cb.BeginText();
				cb.SetFontAndSize(bf, 8);
				cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, 
				"Printed On " + PrintTime.ToString(), 
				pageSize.GetRight(40), 
				pageSize.GetBottom(30), 0);
				cb.EndText();
			}
			public override void OnCloseDocument(PdfWriter writer, Document document)
			{
				base.OnCloseDocument(writer, document);
				template.BeginText();
				template.SetFontAndSize(bf, 8);
				template.SetTextMatrix(0, 0);
				template.ShowText("" + (writer.PageNumber - 1));
				template.EndText();
			}
		}
	}

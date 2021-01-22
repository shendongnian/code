		private static void SetRichText(RichTextBox rtb, string[] arLines)
		{
			Contract.Assert(arLines.All(l => l.Length == arLines[0].Length));
			FlowDocument doc = new FlowDocument { PageWidth = 65535.0 };
			IEnumerable<Paragraph> iep = arLines.Select(l =>
			                                  	{
			                                  		Paragraph p = new Paragraph();
			                                  		p.Inlines.Add(new Run(l));
			                                  		return p;
			                                  	});
			foreach (Paragraph p in iep)
			{
				doc.Blocks.Add(p);
			}
			rtb.Document = doc;
			doc.PagePadding = new Thickness(0, 0, 0, 0);
			
			Rect rcEOL = rtb.Document.ContentStart.GetPositionAtOffset(arLines[0].Length).GetCharacterRect(LogicalDirection.Forward);
			// TODO : Figure why I have to add a fudge factor in the following (I'm guessing some margin I'm unaware of in the 
			// RichTextBox somewhere)...
			rtb.Document.PageWidth = rcEOL.Right + 18;
		}

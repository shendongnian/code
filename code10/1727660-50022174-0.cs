    ParagraphProperties pProp = new ParagraphProperties();
    Justification just = new Justification() { Val = JustificationValues.Both };
	pProp.Append(just);
	var run = new Run(new Text(slText));
	var para = new Paragraph();
	para.Append(pProp);
	para.Append(run);
	bookmark.Parent.InsertAfterSelf(para);

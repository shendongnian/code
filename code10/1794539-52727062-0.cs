    colParagraph.Range.InsertAfter(MARKUP_WORD_TAB);
    colParagraph = wordRng.Paragraphs.Last;         //reset the range to include the tab so the style can be applied.
	colParagraph.set_Style(wordDoc.Styles["ColumnHeadings"]);
	int year;
	int start = colParagraph.Range.Text.Length - 1;
	string yrHeading = string.Empty;
	Word.Range underlineRange = null;
	for (int i = 0 ; i < fiscalYears.Length; i++)
	{
	    year = fiscalYears[i];
	    colParagraph = wordRng.Paragraphs.Last;         //reset the range to include the last fiscal year that was entered.
	    start = colParagraph.Range.Text.Length - 1;
	    colParagraph.Range.InsertAfter(yrHeading);
	    colParagraph.Range.InsertAfter(MARKUP_WORD_TAB);
	    underlineRange = colParagraph.Range.Duplicate;
	    underlineRange.MoveStart(Word.WdUnits.wdCharacter, start);
	    underlineRange.MoveEnd(Word.WdUnits.wdCharacter, -2);           //-2 = /t/r for tab & paragraph characters
	    underlineRange.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
	}
	colParagraph = wordRng.Paragraphs.Add();

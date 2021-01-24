    private void AddTableRepeatingSection()
    {
        //Programatically duplicates the table as a repeating section
        Word.Table table = this.Sections[1].Range.Tables[1];
        Word.Range rSRange = table.Range;
        rSRange.Select();
        Word.Range r = this.Application.Selection.Range;
        Word.ContentControl rSCC = this.ContentControls.Add
            (Word.WdContentControlType.wdContentControlRepeatingSection, r);
        rSCC.RepeatingSectionItems[1].InsertItemAfter();
    }

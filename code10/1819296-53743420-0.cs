    private static Microsoft.Office.Interop.Word.Application Application => Globals.ThisAddIn.Application;
    private void InsertCoverPage(BuildingBlock buildingBlock)
    {
        // validate not null
        if(buildingBlock == null) throw new ArgumentNullException(nameof(buildingBlock));
        // validate is a cover page
        if (buildingBlock.Type.Index != (int)WdBuildingBlockTypes.wdTypeCoverPage &&
            buildingBlock.Type.Index != (int)WdBuildingBlockTypes.wdTypeCustomCoverPage)
        {
            throw new ArgumentNullException(nameof(buildingBlock));
        }
        // validate insert option
        if (buildingBlock.InsertOptions != (int) WdDocPartInsertOptions.wdInsertPage) 
        {
            throw new Exception(
                "building block as a cover page must been inserted in a new page at the beginning of document");
        }
        
        Application.ScreenUpdating = false;
        
        Range range = GetCurrentCoverPageRange() ?? Application.ActiveDocument.Range(0, 0);// search a first existing cover page range
        range.InsertBreak(WdBreakType.wdPageBreak); // case existing cover page: replace by page break 
        // range.Start = 0; // = 0
        range.End = 0; // reset only end position
        buildingBlock.Insert(range, true);
        
        Marshal.ReleaseComObject(range);
        Application.ScreenUpdating = true;
    }
    private Range GetCurrentCoverPageRange()
    {
        Range result = null;
        // Word insert natively a cover page with 2 paragraphs - so we need found these first 2 consecutive paragraphs marked as a cover page
        for (int i = 1; i < Application.ActiveDocument.Paragraphs.Count + 1; i++)
        {
            var paragraph = Application.ActiveDocument.Paragraphs[i];
            var isCoverPage = (bool)paragraph.Range.Information[WdInformation.wdInCoverPage];
            if (isCoverPage)
            {
                if (result == null)
                {
                    result = paragraph.Range;
                }
                else
                {
                    result.End = paragraph.Range.End;
                }
            }
            else
            {
                if (result != null)
                {
                    break;
                }
            }
        }
        return result;
    }

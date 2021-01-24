        string CurrentBkm = "_bkmCurrent";
        string LastBkm= "_bkmLast";
            if(docRange.HighlightColorIndex.Equals(Microsoft.Office.Interop.Word.WdColorIndex.wdRed))
            {
                docRange.HighlightColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlue;
                docRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
                if (document.Bookmarks.Exists(CurrentBkm))
                {
                    document.Bookmarks.Add(LastBkm, document.Bookmarks[CurrentBkm].Range.Duplicate);
                }
                document.Bookmarks.Add(CurrentBkm, docRange);
                break;

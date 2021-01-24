    using Microsoft.Office.Interop.Word;
    
    ...
    
    // merge by putting second file into bookmark in first file
    private static void NewMerge(string firstPath, string secondPath, string resultPath, string firstBookmark)
    {
        var app = new Application();
        var firstDoc = app.Documents.Open(firstPath);
        var bookmarkRange = firstDoc.Bookmarks[firstBookmark];
    
        // Collapse the range to the end, as to not overwrite it. Unsure if you need this
        bookmarkRange.Collapse(WdCollapseDirection.wdCollapseEnd);
    
        // Insert into the selected range
        // use if relative path
        bookmarkRange.InsertFile(Environment.CurrentDirectory + secondPath);
    
        // use if absolute path
        //bookmarkRange.InsertFile(secondPath);
    }

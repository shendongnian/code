    using Microsoft.Office.Interop.Word;
    
    using Microsoft.Office.Core;
    
    Document varDoc = varWord.Documents.Add(ref varMissing, ref varMissing, ref varMissing, ref varTrueValue);
    
    varDoc.Activate();
    
    varDoc.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekCurrentPageHeader;
    
    varDoc.ActiveWindow.Selection.Font.Bold = 1;

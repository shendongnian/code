    Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
    Documents docs = app.Documents;
    Document doc = docs.Open("C:\\users\\Test.docx", ReadOnly:true);
    Table tbl = doc.Tables[1];
    Range rg = tbl.Range;
    Cells cells = rg.Cells;

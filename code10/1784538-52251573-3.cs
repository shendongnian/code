    public void Test2() {
        var newFile = @"newbook.core.docx";
        using (var fs = new FileStream(newFile, FileMode.Create, FileAccess.Write))
        {
            IWorkbook workbook = CreateBook();
            workbook.WriteToResponse2(contextAccessor.HttpContext,"ss.xlsx");
        }
    }

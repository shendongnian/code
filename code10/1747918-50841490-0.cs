    protected virtual byte[] ExportToXlsx<T>(IEnumerable<T> itemsToExport) {
        using (var stream = new MemoryStream()) {
            using (var xlPackage = new ExcelPackage(stream)) { //<<< pass stream
                // get handles to the worksheets
                var worksheet = xlPackage.Workbook.Worksheets.Add(typeof(T).Name);
                //create Headers and format them 
                var manager = new PropertyManager<T>(itemsToExport.First());
                manager.WriteCaption(worksheet, SetCaptionStyle);
                var row = 2;
                foreach (var items in itemsToExport) {
                    manager.CurrentObject = items;
                    manager.WriteToXlsx(worksheet, row++, false);
                }
                xlPackage.Save();
            }
            return stream.ToArray();
        }
    }

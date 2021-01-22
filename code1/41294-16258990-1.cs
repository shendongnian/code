    public static class ExcelExtensions
    {
        /// <summary>
        /// Creates an Excel document from any IEnumerable returns a memory stream
        /// </summary>
        /// <param name="rows">IEnumerable that will be converted into an Excel worksheet</param>
        /// <param name="sheetName">Name of the Ecel Sheet</param>
        /// <returns></returns>
        public static FileStreamResult ToExcel(this IEnumerable<object> rows, string sheetName)
        {
            // Create a new workbook and a sheet named by the sheetName variable
            var workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet(sheetName);
            //these indexes will be used to track to coordinates of data in our IEnumerable
            var rowIndex = 0;
            var cellIndex = 0;
            
            var excelRow = sheet.CreateRow(rowIndex);
            //Get a collection of names for the header by grabbing the name field of the display attribute
            var headerRow = from p in rows.First().GetType().GetProperties()
                            select rows.First().GetAttributeFrom<DisplayAttribute>(p.Name).Name;
            //Add headers to the file
            foreach (string header in headerRow)
            {
                excelRow.CreateCell(cellIndex).SetCellValue(header);
                cellIndex++;
            }
            //reset the cells and go to the next row
            cellIndex = 0;
            rowIndex++;
            //Inset the data row
            foreach (var contentRow in rows)
            {
                excelRow = sheet.CreateRow(rowIndex);
                var Properties = rows.First().GetType().GetProperties();
                //Go through each property and inset it into a single cell
                foreach (var property in Properties)
                {
                    var cell = excelRow.CreateCell(cellIndex);
                    var value = property.GetValue(contentRow);
                    if (value != null)
                    {
                        var dataType = value.GetType();
                        //Set the type of excel cell for different data types
                        if (dataType == typeof(int) ||
                            dataType == typeof(double) ||
                            dataType == typeof(decimal) ||
                            dataType == typeof(float) ||
                            dataType == typeof(long))
                        {
                            cell.SetCellType(CellType.NUMERIC);
                            cell.SetCellValue(Convert.ToDouble(value));
                        }
                        if (dataType == typeof(bool))
                        {
                            cell.SetCellType(CellType.BOOLEAN);
                            cell.SetCellValue(Convert.ToDouble(value));
                        }
                        else
                        {
                            cell.SetCellValue(value.ToString());
                        }
                    }
                    cellIndex++;
                }
                cellIndex = 0;
                rowIndex++;
            }
            //Set the width of the columns
            foreach (string header in headerRow)
            {
                sheet.AutoSizeColumn(cellIndex);
                cellIndex++;
            }
            return workbook.GetDownload(sheetName);
        }
        /// <summary>
        /// Converts the NPOI workbook into a byte array for download
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static FileStreamResult GetDownload(this NPOI.HSSF.UserModel.HSSFWorkbook file, string fileName)
        {
            MemoryStream ms = new MemoryStream();
            file.Write(ms); //.Save() adds the <xml /> header tag!
            ms.Seek(0, SeekOrigin.Begin);
            var r = new FileStreamResult(ms, "application/vnd.ms-excel");
            r.FileDownloadName = String.Format("{0}.xls", fileName.Replace(" ", ""));
            return r;
        }
        /// <summary>
        /// Get's an attribute from any given property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static T GetAttributeFrom<T>(this object instance, string propertyName) where T : Attribute
        {
            var attrType = typeof(T);
            var property = instance.GetType().GetProperty(propertyName);
            return (T)property.GetCustomAttributes(attrType, false).First();
        }
    }

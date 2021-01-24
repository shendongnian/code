        private List<ImportDocs> ParseDocsFromSheet(ISheet sheet){
            IRow headerRow = sheet.GetRow(0); //Get Header Row
            int cellCount = headerRow.LastCellNum;
            // ["Id","LastName","","UserName","","Name"]
            var headerNames= new List<string>();
            for (int j = 0; j < cellCount; j++)
            {
                NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);
                if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) {
                    headerNames.Add("");  // add empty string if cell is empty
                }else{
                    headerNames.Add( cell.ToString());
                }
            }
            var records= new List<ImportDocs>();
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
            {
                IRow row = sheet.GetRow(i);
                if (row == null) continue;
                if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                var record = new ImportDocs();
                var type = typeof(ImportDocs);
                for (int j = 0 ; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null){
                        var field = row.GetCell(j).ToString();
                        var fieldName = headerNames[j];
                        if(String.IsNullOrWhiteSpace(fieldName)){
                            throw new Exception($"There's a value in Cell({i},{j}) but has no header !");
                        }
                        var pi = type.GetProperty(fieldName);
                        // for Id column : a int type
                        if(pi.PropertyType.IsAssignableFrom(typeof(Int32))){
                            pi.SetValue(record,Convert.ToInt32(field));
                        }
                        // for other colun : string
                        else{
                            pi.SetValue(record,field);
                        }
                    }
                }
                records.Add(record);
            }
            return records;
        }

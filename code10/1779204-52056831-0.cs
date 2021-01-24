                //assume _longDataTable has two columns : column1 and SheetCode
            var _longDataTable = new DataTable();
            var duplicatedData = new DataTable();
            duplicatedData.Columns.Add("Column1");
            duplicatedData.Columns.Add("SheetCode");
            foreach (DataRow sheets in _longDataTable.Rows)
            {
                for (int k = 0; k < number_of_sheets; k++)
                {
                    var newRowSheets = duplicatedData.NewRow();
                    newRowSheets.ItemArray = sheets.ItemArray;
                    newRowSheets["SheetCode"] = values.Rows[k]["Sheet Code"];
                    newRowSheets["Column1"] = "anything";
                    //add edited row to long datatable
                    duplicatedData.Rows.Add(newRowSheets);
                }
            }
            _longDataTable.Merge(duplicatedData);
 

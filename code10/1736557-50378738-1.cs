            var data = string.Empty; //String var to hold file
            var tbl = new DataTable("MyData"); //Tmp dataTable object
            using (var fs = new StreamReader(@"C:\Temp\test.csv")) //Open file
                data = fs.ReadToEnd(); //Read entirely into data variable
            var rows = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries); //Split into array by lines. RemoveEmpty's for end of file extra lines.
            var cnt = 0; //Counter to know header
            foreach (var row in rows) //Iterate rows
            {
                var cells = row.Split(new string[] { "\",\"" }, StringSplitOptions.None); //Split row into cells. Leave empties here cause some cells might be empty.
                if (cnt == 0) foreach (var cell in cells) //If is header row add columns
                        tbl.Columns.Add(new DataColumn(cell));
                else //Else data row
                {
                    var dataRow = tbl.NewRow(); //New row
                    dataRow.ItemArray = cells; //Assign cell values
                    tbl.Rows.Add(dataRow); //Add row to table.
                }
                cnt++;
            }

            var cnt = 0; //Row counter
            var tbl = new DataTable("MyData"); //Tmp dataTable object
            using (var fs = new StreamReader(@"C:\Temp\test.csv")) //Load file
            {
                do //Start loop
                {
                    var row = fs.ReadLine(); //Get first line
                    var cells = row.Split(new string[] { "\",\"" }, StringSplitOptions.None); //Split into cells
                    if (cnt == 0) //If is header row
                    {
                        foreach (var cell in cells) //For each header
                            tbl.Columns.Add(new DataColumn(cell)); //Add Column
                    } else { //Not header row
                        var dataRow = tbl.NewRow(); //Create new row based on tmp table
                        dataRow.ItemArray = cells; //Assign cell values
                        tbl.Rows.Add(row); //Add row to table
                    }
                    cnt++;
                } while (!fs.EndOfStream); //If not done loop
            }

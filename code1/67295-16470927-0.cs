    public static DataTable LoadCSV(string path, bool hasHeader)
        {
            DataTable dt = new DataTable();
            using (var MyReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(path))
            {
                MyReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                MyReader.Delimiters = new String[] { "," };
                string[] currentRow;
                //'Loop through all of the fields in the file.  
                //'If any lines are corrupt, report an error and continue parsing.  
                bool firstRow = true;
                while (!MyReader.EndOfData)
                {
                    try
                    {
                        currentRow = MyReader.ReadFields();
                        //Add the header columns
                        if (hasHeader && firstRow)
                        {
                            foreach (string c in currentRow)
                            {
                                dt.Columns.Add(c, typeof(string));
                            }
                            firstRow = false;
                            continue;
                        }
                        //Create a new row
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                        //Loop thru the current line and fill the data out
                        for(int c = 0; c < currentRow.Count(); c++)
                        {
                            dr[c] = currentRow[c];
                        }
                    }
                    catch (Microsoft.VisualBasic.FileIO.MalformedLineException ex)
                    {
                        //Handle the exception here
                    }
                }
            }
            return dt;
        }

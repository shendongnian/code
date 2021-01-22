            using (Microsoft.VisualBasic.FileIO.TextFieldParser MyReader = new           
                      Microsoft.VisualBasic.FileIO.TextFieldParser(filename))
            {
                MyReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                MyReader.SetDelimiters(",");
                while (!MyReader.EndOfData)
                {
                    try
                    {
                        string[] fields = MyReader.ReadFields();
                        if (first) {
                            first = false;
                            continue;
                        }
                        // This is how I treat my data, you'll need to throw this out.
                        //"Type"	"Post Date"	"Description"	"Amount"
                        LineItem li = new LineItem();
                        li.date        = DateTime.Parse(fields[1]);
                        li.description = fields[2];
                        li.Value       = Convert.ToDecimal(fields[3]);
                        
                        lineitems1.Add(li);
                    }
                    catch (Microsoft.VisualBasic.FileIO.MalformedLineException ex)
                    {
                        MessageBox.Show("Line " + ex.Message + "is not valid and will be skipped.");
                    }
                }
            }

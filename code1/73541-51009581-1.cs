    public static List<string> ToExcelsSheetList(string exceladdress)
            {
                List<string> sheets = new List<string>();
                using (OleDbConnection connection = new OleDbConnection((exceladdress.TrimEnd().ToLower().EndsWith("x")) ? "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + exceladdress + "';" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'"
                    : "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + exceladdress + "';Extended Properties=Excel 8.0;"))
                {
                    connection.Open();
                    DataTable dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    foreach (DataRow drSheet in dt.Rows)
                        if (drSheet["TABLE_NAME"].ToString().Contains("$"))
                        {
                            string s = drSheet["TABLE_NAME"].ToString();
                            sheets.Add(s.Substring(1, s.Length - 3));
                        }
                    connection.Close();
                }
                return sheets;
            }

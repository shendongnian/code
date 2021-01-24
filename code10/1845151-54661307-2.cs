    private void button4_Click(object sender, EventArgs e)
            {
                var line = new List<string>();
                line.Add("string;string");
                line.Add("LoginId; No_Intervenant");
                line.Add("EF2KBT0; 1003820030");
                line.Add("ENHD0KE; 1003820129");
                line.Add("E9PM7EP; 1003820153");
                line.Add("EFT10OO; 1003820218");
    
                var fileContent = line.ToArray();
    
                var sqlCommand = new StringBuilder();
                string[] types = fileContent[0].Split(';');
                string[] columns = fileContent[1].Split(';');
    
                //skip the first line (header)
                for (int i = 2; i < fileContent.Length; i++)
                {
                    string[] values = fileContent[i].Split(';');
    
                    if (values.Length >= 1)
                    {
                        AddSqlCommand(sqlCommand, columns, types, values, "client");
                    }
                }
    
            }

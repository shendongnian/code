        static void Main(string[] args)
        {
            string filepath = @"C:\temp\Data.xlsx"; //Location and name of the .xlsx? file
            string connectioninfo = $@"Provider =Microsoft.ACE.OLEDB.12.0;Data Source={ filepath };
                                       Extended Properties = 'Excel 12.0;HDR=YES;IMEX=1;';";
            string query = @"SELECT * FROM [Data$]"; //Worksheet name, if more than one year add a where clause
            List<ExcelDataModel> entries = new List<ExcelDataModel>();
            using (OleDbConnection conn = new OleDbConnection(connectioninfo))
            {
                OleDbCommand command = new OleDbCommand(query, conn);
                conn.Open();
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                        entries.Add(new ExcelDataModel { DT = Convert.ToDateTime(reader[0]),
                                                    High = double.Parse(reader[1].ToString()),
                                                    Low = double.Parse(reader[2].ToString()) });
                conn.Close();
            }
            var values = entries.GroupBy(x => x.DT.Month).Select(i => new { dt = i.Key, High = i.Max(y => y.High), Low = i.Min(y => y.Low) }).ToList();
            //Do whatever you need with the records
            values.ForEach(month => { Console.WriteLine($"Month: { month.dt } \t Highest: { month.High } \t Lowest: { month.Low }"); });
            Console.ReadLine();
        }

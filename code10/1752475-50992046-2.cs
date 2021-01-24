    static void Main(string[] args)
            {
    
                System.Data.DataTable dataGridConfigTable = new System.Data.DataTable();
                dataGridConfigTable.Columns.Add("Parameter1");
                dataGridConfigTable.Columns.Add("Parameter2");
                dataGridConfigTable.Columns.Add("Parameter3");
    
                var row = dataGridConfigTable.NewRow();
                row[0] = "Apple";
                row[1] = "Broccoli";
                row[2] = "Ice Cream";
                dataGridConfigTable.Rows.Add(row);
                row = dataGridConfigTable.NewRow();
                row[0] = "Orange";
                row[1] = "Carrots";
                row[2] = "Pie";
                dataGridConfigTable.Rows.Add(row);
                row = dataGridConfigTable.NewRow();
                row[1] = "Peas";
                dataGridConfigTable.Rows.Add(row);
                row = dataGridConfigTable.NewRow();
                row[1] = "Grean Beans";
                dataGridConfigTable.Rows.Add(row);
    
                var dynamicList = new List<List<string>>();
                foreach (System.Data.DataColumn dc in dataGridConfigTable.Columns)
                {
                    dynamicList.Add(dataGridConfigTable.AsEnumerable().Select(s => s.Field<string>(dc.ColumnName)).Where(x => x != null).ToList());
                }
    
                List<string> result = null;
                dynamicList.ForEach(x => BuildString(ref result, x));
                result.ForEach(i => Console.WriteLine(i));
                Console.ReadLine();
            }
    
            static void BuildString(ref List<string> param1List, List<string> param2List)
            {
                if (param1List == null)
                {
                    param1List = param2List;
                    return;
                }
    
                List<string> result = new List<string>();
                param1List.ForEach(x => param2List.ForEach(y => result.Add(String.Format("{0} - {1}", x, y))));
                param1List = result;
    
            }
     

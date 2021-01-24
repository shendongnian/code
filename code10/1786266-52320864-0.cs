     static void Main(string[] args)
        {
            DataTable dt = new DataTable("Items");
            string xmlFile = @"new.xml";
    
            DataSet ds = new DataSet();
            ds.ReadXml(xmlFile);
    
            foreach (DataRow rowCol in ds.Tables["bomcol"].Rows)
            {
                dt.Columns.Add(rowCol.ItemArray[2].ToString());
            }
    
            DataRow dr = dt.Rows.Add();
            for (int j = 0; j < ds.Tables["bomcell"].Rows.Count; j++)
            {
    
                var i = j % 5;
                if (i == 0 && j != 0)
                {
                    dr = dt.Rows.Add();
                }
    
                dr[dt.Columns[i]] = ds.Tables["bomcell"].Rows[j].ItemArray[1];
            }
    
            Console.WriteLine("Rows: " + dt.Rows.Count);
            Console.WriteLine("Cols: " + dt.Columns.Count);
            DataColumnCollection cols = dt.Columns;
            foreach (DataColumn col in cols)
            {
                Console.Write(cols[0] + "\t");
            }
    
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine();
                Console.Write(row.ItemArray[0] + "\t\t" + row.ItemArray[1] + "\t\t" + row.ItemArray[2] + "\t\t" + row.ItemArray[3] + "\t\t" + row.ItemArray[4] + "\t");
            }
    
            Console.ReadLine();
        }

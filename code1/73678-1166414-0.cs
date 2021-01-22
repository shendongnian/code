            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            var lines = File.ReadAllLines(@"c:\tabfile.txt");
            foreach( string line in lines )
                dt.Rows.Add(line.Split('\t'));

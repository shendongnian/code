            List<List<int>> table = new List<List<int>>();
            List<int> row = new List<int>();
            row.Add(21);
            row.Add(22);
            row.Add(23);
            row.Add(33); // and so on
            table.Add(row);
            row = new List<int>();
            row.Add(1001);
            row.Add(1002);
            table.Add(row);
            MessageBox.Show(table[0][3].ToString());

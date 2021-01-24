                string[] columnNames = { "A", "B", "C", "D" };
                string[] filteredColumns = { "A", "C", "D" };
                string[] csv = {
                                   "1,2,3,4",
                                   "11,12,13,14",
                                   "21,22,23,24",
                                   "31,32,33,34"
                               };
                int[] indexes = columnNames.Select((x, i) => new { x = x, i = i }).Where(x => filteredColumns.Contains(x.x)).Select(x => x.i).ToArray();
                var results = csv.Select(x => x.Split(new char[] { ',' }).Where((y, i) => indexes.Contains(i)).ToArray()).ToArray();

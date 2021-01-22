            List<ColumnHeader> cols = new List<ColumnHeader>();
            // populate
            foreach (ColumnHeader column in listView.Columns) {
                cols.Add(column);
            }
            // sort
            cols.Sort(delegate(ColumnHeader x, ColumnHeader y) {
                return x.DisplayIndex.CompareTo(y.DisplayIndex);
            });
            // project
            List<string> names = cols.ConvertAll<string>(delegate(ColumnHeader x) {
                return x.Text;
            });

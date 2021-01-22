    class RowsList : List<Row> {
        public Row this[string key] {
            get { return this.Where( x => x.Name == key ).FirstOrDefault(); }
        }
    }

    public class Tbl
    {
        public List<Row> Rows { get; set; }
        public Row this[string name]
        {
            get
            {
                return Rows.Where(r => r.Name == name).FirstOrDefault();
            }
        }
    }

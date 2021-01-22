    public class Tbl
    {
        public List<Row> Rows { get; set; }
        public string this[string name]
        {
            get
            {
                return Rows.Where(r => r.Name == name).FirstOrDefault();
            }
        }
    }

    public class SvcVssRecord
    {
        public SvcVssRecord(double svc, double vss)
        {
            Svc = svc;
            Vss = vss;
        }
        public double Svc { get; set; }
        public double Vss { get; set; }
    }
    public class Builder
    {
        private readonly Dictionary<string, SvcVssRecord> _records;
        public Builder()
        {
            _records = new Dictionary<string, SvcVssRecord>();
        }
        public void Add(string user, string unit, double score)
        {
            int result;
            bool scoreIsSvc = !int.TryParse(unit, out result);
            if (!_records.ContainsKey(user))
            {
                _records.Add(user, new SvcVssRecord(scoreIsSvc ? score : 0, scoreIsSvc ? 0 : score));
            }
            else
            {
                if (scoreIsSvc)
                {
                    _records[user].Svc += score;
                }
                else
                {
                    _records[user].Vss += score;
                }
                
            }
        }
        public DataTable ToDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("User"));
            dt.Columns.Add(new DataColumn("Svc"));
            dt.Columns.Add(new DataColumn("Vss"));
            foreach(var key in _records.Keys)
            {
                DataRow dr = dt.NewRow();
                dr["User"] = key;
                dr["Svc"] = _records[key].Svc;
                dr["Vss"] = _records[key].Vss;
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
    public class Run
    {
        public void RunApp(DataTable source)
        {
            Builder b = new Builder();
            foreach (DataRow dr in source.Rows)
            {
                b.Add((string) dr["User"], (string) dr["Unit"], (double) dr["Score"]);
            }
            DataTable dt = b.ToDataTable();
        }
    }

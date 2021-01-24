        static void Main(string[] args)
        {
            var records = GetNonDuplicateRecords("Records");
        }
        public static IQueryable<T> GetTable<T>(string tblName)
        {
            ALLDBEntities db = new ALLDBEntities();
            var table = db.GetType().GetProperty(tblName).GetValue(db) as List<T>;
            return table.AsQueryable();
        }
        public static List<Records> GetNonDuplicateRecords(string tableName)
        {
            List<Records> recs = (from p in GetTable<RecordTable>(tableName)
                                select new Records
                                {
                                    _claimNumber = p.ClaimNumber,
                                    _firstname = p.PatientFirstName,
                                    _lastname = p.PatientLastName,
                                    _client = p.Client
                                }).ToList<Records>();
            return recs;
        }
        public class Records
        {
            public object _claimNumber { get; set; }
            public object _firstname { get; internal set; }
            public object _lastname { get; internal set; }
            public object _client { get; internal set; }
        }
        public class RecordTable
        {
            public object ClaimNumber { get; set; }
            public object PatientFirstName { get; internal set; }
            public object PatientLastName { get; internal set; }
            public object Client { get; internal set; }
        }
        public class ALLDBEntities
        {
            public List<RecordTable> Records { get; set; } = new List<RecordTable>
            {
                new RecordTable{ClaimNumber = "asdadsasd"}
            };
        }

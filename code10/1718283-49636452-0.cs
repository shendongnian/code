    public List<ReturnClass> GetResults(int[] ids)
        {
            using (var conn = new DB2Connection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction(IsolationLevel.ReadCommitted))
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    var parms = new List<string>();
                    var idCount = 0;
                    foreach (var id in ids)
                    {
                        var parm = "@id" + idCount++;
                        parms.Add(parm);
                        cmd.Parameters.Add(parm, DB2Type.Integer).Value = id;
                    }
                    cmd.CommandText = "SELECT DISTINCT ID,COL2,COL3 FROM TABLE WHERE ID IN ( " + string.Join(",", parms) + " ) ";
                    var resultList = new List<ReturnClass>();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var values = new ReturnClass();
                            values.Id = (int)reader["ID"];
                            values.Col1 = reader["COL1"].ToString();
                            values.Col2 = reader["COL2"].ToString();
                            resultList.Add(values);
                        }
                    }
                    return resultList;
                }
            }
        }
        public class ReturnClass
        {
            public int Id;
            public string Col1;
            public string Col2;
        }

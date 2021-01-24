            string sql = "SELECT X, Y FROM Z WHERE ABC = @ABC";
            using (var conn = new OracleConnection("Password=xxxxx;Persist Security Info=True;User ID=xxxxx;Data Source=xxxxx"))
            using (var multi = conn.QueryMultiple(sql, new {ABC = 123}))
            {
                var results = multi.Read<Z>().ToList();
                Console.Write(string.Join(System.Environment.NewLine, results.Count));
                foreach (string value in results)
                {
                    Console.WriteLine("> X:{0} Y:{1}",value.X, value.Y);
                }
            }

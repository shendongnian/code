    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    class Program {
        static void Main(string[] args) {
            string conStr = @"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=vm-jp-dev2;Data Source='scsql\sql;2005';Auto Translate=False";
            var cb = new DbConnectionStringBuilder();
            cb.ConnectionString = conStr;
            int n = 0;
            foreach (KeyValuePair<string, object> c in cb) {
                Console.WriteLine("#{0}: {1}={2}", ++n, c.Key, c.Value);
            }
        }
    }

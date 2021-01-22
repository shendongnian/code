        private class Process
        {
            public Int64 Id { get; set; }
            public string User { get; set; }
            public string Host { get; set; }
            public string Db { get; set; }
            public string Command { get; set; }
            public string State { get; set; }
            public string Info { get; set; }
        }
        var result = DB.Query().ExecuteTypedList<Process>("SHOW FULL PROCESSLIST");

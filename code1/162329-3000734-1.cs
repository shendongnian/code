            public IList<LogRow> GetLog()
            {
                return Load("SELECT *, OUT_ROW_NUMBER() FROM logfile*.log WHERE Field2='Performance' ORDER BY Field1 ASC");
            }
    
        private static IList<LogRow> Load(string sql)
        {
            IEnumerable<string[]> log = ParseLog(sql);
            return Convert(log);
        }
        private static IList<LogRow> Convert(IEnumerable<string[]> log)
        {
            return log.Select(logRecord => new LogRow
                                               {
                                                   TimeStamp = logRecord[2],
                                                   Category = logRecord[3],
                                                   Machine = logRecord[4],
                                                   ThreadId = logRecord[5],
                                                   ProcessId = logRecord[6],
                                                   ProcessName = logRecord[7],
                                                   DomainName = logRecord[8],
                                                   Message = logRecord[9],
                                                   Number = logRecord[10]
                                               }).ToList();
        }
    
            private static IEnumerable<string[]> ParseLog(string query)
            {
                var records = new LogQueryClassClass().Execute(
                    query,
                    new COMCSVInputContextClass { headerRow = false, iTsFormat = "yyyy-MM-dd HH:mm:ss.fff" });
                var entries = new List<string[]>();
    
                while (!records.atEnd())
                {
                    entries.Add(records.getRecord().toNativeString("CSVseparator").Split(
                                    new[] { "CSVseparator" },
                                    StringSplitOptions.None));
                    records.moveNext();
                }
    
                records.close();
                return entries;
            }
    
    
     

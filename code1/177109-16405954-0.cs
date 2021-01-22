                var query = String.Format("select MessagesinQueue from Win32_PerfRawdata_MSMQ_MSMQQueue where name ='{0}'", path.Replace("\\", "\\\\"));
            var selectQuery = new SelectQuery(query);
            using (var searcher = new ManagementObjectSearcher(selectQuery))
            using (var results = searcher.Get())
            {
                foreach (var result in results)
                {
                    var messages = result["MessagesinQueue"].ToString();
                    return long.Parse(messages);
                }
            }

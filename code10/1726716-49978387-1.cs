        static void Main(string[] args)
        {
            List<Process> processes = new List<Process>();
            OracleDataReader reader = null;
            int? parentId = null;
            Process currentProcess = null;
            // Assumes that query results are ordered in a way that parent records appear before the child records
            while (reader.Read())
            {
                // Get the parent id from reader. Change index as per your need
                if (!reader.IsDBNull(1) && ((parentId = reader.GetInt32(1)) != null))
                {
                    currentProcess = GetProcessRecord(processes, parentId);
                    // add values to children to current process here
                }
            }
        }
        private static Process GetProcessRecord(List<Process> processes, int? parentId)
        {
            Process currentProcess = null;
            // This record has a parent. See if we already have it.
            if (processes.Any(x => x.Id == parentId))
            {
                // Found the parent record at level 0
                currentProcess = processes.First(x => x.Id == parentId);
                if (currentProcess.Children == null)
                {
                    currentProcess.Children = new List<Process>();
                }
            }
            else
            {
                // Might be a child record of another parent
                foreach (var process in processes)
                {
                    if (process.Children != null)
                    {
                        currentProcess = GetProcessRecord(process.Children, parentId);
                        if (currentProcess != null)
                        {
                            return currentProcess;
                        }
                    }
                }
            }
            return currentProcess;
        }

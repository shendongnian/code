        public DataTable GetProcessTable()
        {
            DataTable MethodResult = null;
            try
            {
                List<Process> Processes = Process.GetProcesses().ToList<Process>();
                DataTable dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns["Name"].ReadOnly = true;
                dt.Columns.Add("Id", typeof(string));
                dt.Columns["Id"].ReadOnly = true;
                dt.Columns.Add("Owner", typeof(string));
                dt.Columns["Owner"].ReadOnly = true;
                foreach (Process p in Processes)
                {
                    string Owner = GetProcessOwner(p.Id);
                    if (Owner.Contains(TxtUsername.Text))
                    {
                        DataRow r = dt.NewRow();
                        bool Match = false;
                        
                        r["Id"] = p.Id.ToString();
                        r["Name"] = p.ProcessName;
                        r["Owner"] = GetProcessOwner(p.Id);
                            
                        dt.Rows.Add(r);
                    }
                }
                MethodResult = dt;
            }
            catch //(Exception ex)
            {
                //ex.HandleException();
            }
            return MethodResult;
        }

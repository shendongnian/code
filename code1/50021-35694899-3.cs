        public string GetProcessOwner(int processId)
        {
            string MethodResult = null;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" SELECT ");
                sb.Append("     * ");
                sb.Append(" FROM ");
                sb.Append("     WIN32_PROCESS");
                sb.Append(" WHERE ");
                sb.Append("     ProcessId = " + processId);
                
                string Query = sb.ToString();
                
                ManagementObjectCollection Processes = new ManagementObjectSearcher(Query).Get();
                foreach (ManagementObject Process in Processes)
                {
                    string[] Args = new string[] { "", "" };
                    int ReturnCode = Convert.ToInt32(Process.InvokeMethod("GetOwner", Args));
                    switch(ReturnCode)
                    {
                        case 0:
                            MethodResult = Args[1] + "\\" + Args[0];
                            break;
                        default:
                            MethodResult = "None";
                            break;
                    }
                }
            }
            catch //(Exception ex)
            {
                //ex.HandleException();
            }
            return MethodResult;
        }

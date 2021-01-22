        public static WindowsIdentity GetUserName(int sessionId)
        {
            foreach (Process p in Process.GetProcesses())
            {
                if(p.SessionId == sessionId) {                    
                    return new WindowsIdentity(p.Handle);                          
                }                
            }
            return null;
        }

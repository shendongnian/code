            List<Process> processes = helper.Query<Process>().ToList();
            foreach (Process p in processes)
            {
                pid = p.ProcessID;
                name = p.Name;
                path = p.ExecutablePath ?? String.Empty;
                priort = p.Priority ?? String.Empty;
                dynamic d = p.GetOwnerSid();
                ProcessOwner po = p.GetOwner();
            }

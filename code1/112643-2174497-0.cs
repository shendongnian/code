        private void KillProcess(string name)
        {
            var binpath = Server.MapPath("~/bin");
            var pp2 = Process.GetProcesses();
            var pp = from p in pp2 where p.ProcessName.Contains(name) && !p.ProcessName.Contains("vshost") select p;
            foreach (var p in pp)
            {
                p.Kill();
            }
        }
    [WebMethod]
        public void StartQueueRunner()
        {
            var binpath = Server.MapPath("~/bin");
            System.Diagnostics.Process.Start(Path.Combine(binpath, "TwoNeeds.QueueRunner.exe"));
        }
    [WebMethod]
        public void StartQueueRunner()
        {
            var binpath = Server.MapPath("~/bin");
            System.Diagnostics.Process.Start(Path.Combine(binpath, "TwoNeeds.QueueRunner.exe"));
        }

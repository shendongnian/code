    using (WindowsImpersonationContext context = ImpersonateUser("domain", "user", "password"))
        {
            Process[] proc = Process.GetProcessesByName("process name");
            if (proc.Length > 0)
                proc[0].Kill();
            context.Undo();
        }

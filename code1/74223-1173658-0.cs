    class Program
    {
        static void Main(string[] args)
        {
            var psi = new ProcessStartInfo(@"c:\windows\system32\whoami.exe");
            var password = new SecureString();
            password.AppendChar('s');
            password.AppendChar('e');
            password.AppendChar('c');
            password.AppendChar('r');
            password.AppendChar('e');
            password.AppendChar('t');
            psi.Password = password;
            psi.UserName = "username";
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            var p = new Process();
            p.StartInfo = psi;
            p.Start();
            p.WaitForExit();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
        }
    }

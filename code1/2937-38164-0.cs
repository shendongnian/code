    using System;
    using System.IO;
    using System.Text;
    using System.Security;
    using System.Diagnostics;
    namespace asdf
    {
        class StackoverflowQuestion
        {
            private const string MSBUILD = @"path\to\msbuild.exe";
            private const string BMAIL = @"path\to\bmail.exe";
            private const string WORKING_DIR = @"path\to\working_directory";
            private string stdout;
            private Process p;
            public void DoWork()
            {
                // build project
                StartProcess(MSBUILD, "myproject.csproj /t:Build", true);
            }
            public void StartProcess(string file, string args, bool redirectStdout)
            {
                SecureString password = new SecureString();
                foreach (char c in "mypassword".ToCharArray())
                    password.AppendChar(c);
                ProcessStartInfo psi = new ProcessStartInfo();
                p = new Process();
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.WorkingDirectory = WORKING_DIR;
                psi.FileName = file;
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = redirectStdout;
                psi.UserName = "builder";
                psi.Password = password;
                p.StartInfo = psi;
                p.EnableRaisingEvents = true;
                p.Exited += new EventHandler(p_Exited);
                p.Start();
                if (redirectStdout)
                {
                    stdout = p.StandardOutput.ReadToEnd();
                }
            }
            void p_Exited(object sender, EventArgs e)
            {
                if (p.ExitCode != 0)
                {
                    // failed
                    StringBuilder args = new StringBuilder();
                    args.Append("-s k2smtpout.secureserver.net ");
                    args.Append("-f build@example.com ");
                    args.Append("-t josh@example.com ");
                    args.Append("-a \"Build failed.\" ");
                    args.AppendFormat("-m {0} -h", stdout);
                    // send email
                    StartProcess(BMAIL, args.ToString(), false);
                }
            }
        }
    }

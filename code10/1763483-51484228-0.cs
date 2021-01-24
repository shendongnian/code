    public static class SshClientExt {
        public static ExtShellStream CreateExtShellStream(this SshClient sc, string termName, uint rows, uint cols, uint width, uint height, int bufSize) =>
            new ExtShellStream(sc.CreateShellStream(termName, rows, cols, width, height, bufSize));
    }
    
    public class ExtShellStream : IDisposable {
        static Regex reEscVT100 = new Regex("\x1B\\[[^A-Z]+[A-Z]", RegexOptions.Compiled);
        static TimeSpan ReadTimeout = new TimeSpan(0, 0, 10);
    
        ShellStream ssh;
        StreamReader sr;
        StreamWriter sw;
    
        public ExtShellStream(ShellStream anSSH) {
            ssh = anSSH;
            sr = new StreamReader(ssh);
            sw = new StreamWriter(ssh);
        }
    
        public List<string> ReadLines() {
            // try to read all in
            long prev;
            do {
                prev = ssh.Length;
                Thread.Sleep(250);
            } while (ssh.Length != prev);
    
            "-".Repeat(40).Dump();
            var ans = new List<string>();
    
            while (true) {
                var line = sr.ReadLine();
                if (line != null) {
                    line = line.Remove(reEscVT100).TrimEnd();
                    $@"""{line}""".Dump();
                    if (line.EndsWith("#")) // stop when prompt appears
                        break;
                    else
                        ans.Add(line);
                }
                else
                    Thread.Sleep(500);
            }
    
            return ans;
        }
    
        public void DumpLines() => ReadLines();
    
        public List<string> DoCommand(string cmd) {
            sw.Write(cmd);
            sw.Write("\r");
            sw.Flush();
            while (!ssh.DataAvailable)
                Thread.Sleep(500);
            return ReadLines().SkipWhile(l => l == cmd).ToList();
        }
    
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
    
        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    sw.Dispose();
                    sr.Dispose();
                    ssh.Dispose();
                }
    
                disposedValue = true;
            }
        }
    
        // This code added to correctly implement the disposable pattern.
        public void Dispose() {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    
    }

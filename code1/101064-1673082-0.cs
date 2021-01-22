        public void Print(string pathname, string acrobatDirectory)
        {
            var proc = new Process
            {
                StartInfo =
                {
                    Arguments               = String.Format("/t \"{0}\"", pathname),
                    FileName = acrobatDirectory,
                    UseShellExecute         = false,
                    CreateNoWindow          = true,
                    RedirectStandardOutput  = false,
                    RedirectStandardError   = false,
                }
            };
            proc.Start();  
        }  

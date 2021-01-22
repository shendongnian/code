            using (Stream stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                if (stream != null)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("Output file {0} ready.", fileName));
                    break;
                }
            }

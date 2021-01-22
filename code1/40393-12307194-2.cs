    using System.Diagnostics;
    using System.IO;
    
    namespace Writers
    {
        public class TraceTextWriter : ActionTextWriter
        {
            public TraceTextWriter()
            {
                Actions.Add(s => Trace.Write(s));
            }
        }
    
        public class FileTextWriter : ActionTextWriter
        {
            public FileTextWriter(string path, bool append = false)
            {
                var sw = new StreamWriter(path, append) {AutoFlush = true};
                Actions.Add(sw.Write);
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    namespace appender
    {
        class Program
        {
            static void AppendToFile(FileInfo fi)
            {
                if (!fi.Exists) { return; }
                using (Stream stm = fi.OpenWrite())
                {
                    stm.Seek(0, SeekOrigin.End);
                    using (StreamWriter output = new StreamWriter(stm))
                    {
                        output.WriteLine("M  END");
                        output.Close();
                    }
                }
            }
            static void Main(string[] args)
            {
                DirectoryInfo di = new DirectoryInfo("C:\\abc\\");
                FileInfo[] fiItems = di.GetFiles("*.mol");
                foreach (FileInfo fi in fiItems)
                {
                    AppendToFile(fi);
                }
            }
        }
    }

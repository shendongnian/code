    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var hyphen = "\u2010\r\n";
                var encoding = Encoding.UTF8;
                var bytes = encoding.GetBytes(hyphen);
                using (var stream = new System.IO.FileStream(@"c:\tmp\hyphen.txt", System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
        }
    }

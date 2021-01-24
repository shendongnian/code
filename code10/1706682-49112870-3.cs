    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;
    namespace Recurser
    {
        public class Files : List<FileInfo>
        {
            public Files()
            {
            }
            public override string ToString()
            {
                base.Sort(new FileComparer());
                StringBuilder stringBuilder = new StringBuilder();
                base.ForEach((FileInfo File) => {
                    stringBuilder.Append(File.FullName);
                    stringBuilder.Append("\r\n");
                });
                return stringBuilder.ToString();
            }
            public List<string> ToStrings()
            {
                List<string> strs = new List<string>();
                base.ForEach((FileInfo File) => strs.Add(File.FullName));
                return strs;
            }
        }
    }

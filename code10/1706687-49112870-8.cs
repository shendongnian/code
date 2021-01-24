    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
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
                base.ForEach((FileInfo File) => stringBuilder.AppendLine(File.FullName));
                return stringBuilder.ToString();
            }
            public IEnumerable<string> ToStrings()
            {
                base.Sort(new FileComparer());
                return this.Select((FileInfo File) => File.fullName);
            }
        }
    }

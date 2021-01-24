    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    namespace Recurser
    {
        public class Folders : List<DirectoryInfo>
        {
            public Folders()
            {
            }
            public override string ToString()
            {
                base.Sort(new FolderComparer());
                StringBuilder stringBuilder = new StringBuilder();
                base.ForEach((DirectoryInfo Folder) => stringBuilder.AppendLine(Folder.FullName));
                return stringBuilder.ToString();
            }
            public IEnumerable<string> ToStrings()
            {
                base.Sort(new FolderComparer());
                return this.Select((DirectoryInfo Folder) => Folder.fullName);
            }
        }
    }

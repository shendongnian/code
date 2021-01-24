    using System;
    using System.Collections.Generic;
    using System.IO;
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
                base.ForEach((DirectoryInfo Folder) => {
                    stringBuilder.Append(Folder.FullName);
                    stringBuilder.Append("\r\n");
                });
                return stringBuilder.ToString();
            }
            public List<string> ToStrings()
            {
                List<string> strs = new List<string>();
                base.ForEach((DirectoryInfo Folder) => strs.Add(Folder.FullName));
                return strs;
            }
        }
    }

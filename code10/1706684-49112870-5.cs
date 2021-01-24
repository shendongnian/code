    using System;
    using System.Collections.Generic;
    using System.IO;
    namespace Recurser
    {
        public class FileComparer : IComparer<FileInfo>
        {
            public FileComparer()
            {
            }
            public int Compare(FileInfo X, FileInfo Y)
            {
                return X.FullName.CompareTo(Y.FullName);
            }
        }
    }

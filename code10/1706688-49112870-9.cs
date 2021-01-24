    using System;
    using System.Collections.Generic;
    using System.IO;
    namespace Recurser
    {
        public class FolderComparer : IComparer<DirectoryInfo>
        {
            public FolderComparer()
            {
            }
            public int Compare(DirectoryInfo X, DirectoryInfo Y)
            {
                return X.FullName.CompareTo(Y.FullName);
            }
        }
    }

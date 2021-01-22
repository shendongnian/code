System.IO.FileInfo[] array = new System.IO.DirectoryInfo("directory_path").GetFiles();
Array.Sort<System.IO.FileInfo>(array, delegate(System.IO.FileInfo f1, System.IO.FileInfo f2)
            {
                return f2.CreationTimeUtc.CompareTo(f1.CreationTimeUtc);
            });

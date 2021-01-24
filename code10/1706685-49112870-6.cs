    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;
    namespace Recurser
    {
        public class Recurser
        {
            public Files Files
            {
                get;
            }
            public Folders Folders
            {
                get;
            }
            public string RootFolder
            {
                get;
            }
            public string SearchPattern
            {
                get;
            }
            public Recurser(string RootFolder) : this(RootFolder, "*.*")
            {
            }
            public Recurser(string RootFolder, string SearchPattern)
            {
                this.Folders = new Folders();
                this.Files = new Files();
                this.SearchPattern = SearchPattern;
                this.RootFolder = RootFolder;
            }
            public void Start()
            {
                this.Folders.Clear();
                this.Files.Clear();
                int iCount = 0;
                if (Directory.Exists(this.RootFolder))
                {
                    this.Folders.Add(new DirectoryInfo(this.RootFolder));
                    while (iCount < this.Folders.Count)
                    {
                        this.Folders.AddRange((IEnumerable<DirectoryInfo>)Directory.GetDirectories(this.Folders[iCount].FullName));
                        this.Files.AddRange((IEnumerable<FileInfo>)Directory.GetDirectories(this.Folders[iCount].FullName));
                        iCount = checked(iCount + 1);
                    }
                }
            }
        }
    }

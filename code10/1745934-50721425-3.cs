    //Rextester.Program.Main is the entry point for your code. Don't change it.
    //Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    namespace Rextester
    {
    
        public class Folder
        {
            public string Name { get; set; }
    
            public List<Folder> Folders { get; internal set; }
    
            public Folder()
            {
                this.Folders = new List<Folder>();
            }
    
           public static IEnumerable<Folder> Parse(IEnumerable<string> locations)
            {
                var folders = new List<Folder>();
                foreach (var location in locations)
                {
                    var parts = location.Split(new[]{Path.DirectorySeparatorChar}, StringSplitOptions.RemoveEmptyEntries);
                    Folder currentFolder = null;
                    foreach (var part in parts)
                    {
                        var parentFolders = currentFolder!=null ? currentFolder.Folders : folders;
                        currentFolder = parentFolders.Find(folder => folder.Name == part) ?? new Folder { Name = part };
                        if (!parentFolders.Any(folder => folder.Name.Equals(currentFolder.Name)))
                        {
                            parentFolders.Add(currentFolder);
                        }
                    }
                }
                return folders;
            }
    
            public override string ToString()
            {
                if (this.Folders.Count == 0)
                {
                    return this.Name;
                }
                else
                {
                    var folders = this.Folders
                        .SelectMany(folder => folder.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None))
                        .Select(f => this.Name + Path.DirectorySeparatorChar + f);
                    return string.Join(Environment.NewLine, folders);
                }
    
            }
        }
    
        public class Program
        {
            public static void Main(string[] args)
            {
                var locationList = new List<string>()
                                       {
                                           @"My Folder\Images",
                                           @"My Folder\Media",
                                           @"My Folder\Images\Gif",
                                           @"My Folder\Images\JPG",
                                           @"My Folder\Media\Mov",
                                           @"My Folder\Media\Mov\QT",
                                           @"My Folder\Media\MPG"
                                       };
                var folderLists = Folder.Parse(locationList);
                Console.WriteLine(string.Join(Environment.NewLine, folderLists));
                Console.ReadLine();
            }
        }
    }

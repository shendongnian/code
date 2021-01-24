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

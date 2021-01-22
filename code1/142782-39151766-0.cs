    private List<string> NetworkHosts
        {
            get
            {
                var result = new List<string>();
                var root = new DirectoryEntry("WinNT:");
                foreach (DirectoryEntry computers in root.Children)
                {
                    result.AddRange(from DirectoryEntry computer in computers.Children where computer.Name != "Schema" select computer.Name);
                }
                return result;
            }
        }

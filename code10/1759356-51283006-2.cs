        static void getSubDirectoryList(string workingDirectory)
        {
            string[] directories = Directory.GetDirectories(workingDirectory);
            foreach (string directory in directories)
            {
                if(directory.Contains("AppPacks") || directory.Contains("Managing"))
                {
                    string[] filter = {@"F:\Apps\AppPacks", @"F:\Apps\Managing"};
                    directories = directories.Where(x => x != filter[0]).ToArray();
                    directories = directories.Where(x => x != filter[1]).ToArray();
                }
                Console.WriteLine(directory);
            }
        }

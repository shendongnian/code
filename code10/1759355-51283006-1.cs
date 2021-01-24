        static void getSubDirectoryList(string workingDirectory)
        {
            string[] directories = Directory.GetDirectories(workingDirectory);
            foreach (string directory in directories)
            {
                if(directory.Contains("AppPacks") || directory.Contains("Managing"))
                {
                    string filter = @"F:\Apps\AppPacks";
                    string filter2 = @"F:\Apps\Managing";
                    directories = directories.Where(x => x != filter).ToArray();
                    directories = directories.Where(x => x != filter2).ToArray();
                }
                Console.WriteLine(directory);
            }
        }

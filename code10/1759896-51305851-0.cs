    public static void list_subdir(IListFileItem list)
        {
            Console.WriteLine("subdir");
            CloudFileDirectory fileDirectory = (CloudFileDirectory)list;
            IEnumerable<IListFileItem> fileList = fileDirectory.ListFilesAndDirectories();
            // Print all files/directories in the folder.
            foreach (IListFileItem listItem in fileList)
            {
                // listItem type will be CloudFile or CloudFileDirectory.
                if (listItem.GetType() == typeof(Microsoft.WindowsAzure.Storage.File.CloudFileDirectory))
                {
                    list_subdir(listItem);
                } else {
                    Console.WriteLine(listItem.Uri.Segments.Last());
                }
            }
     }

    public static class OneDriveExtensions
    {
        private static int GetAvailabilityStatusIndex(Folder folder)
        {
            var index = 0;
            while (true)
            {
                var details = folder.GetDetailsOf(folder, index);
                if (details == "Availability status")
                {
                    return index;
                }
                index++;
            }
        }
        public static string OneDriveAvailability(this FileInfo file)
        {
            int availabilityStatusIndex;
            return OneDriveAvailability(file, out availabilityStatusIndex);
        }
        public static string OneDriveAvailability(this FileInfo file,out int availabilityStatusIndex)
        {
            
            Shell shell = new Shell();
            Folder objFolder = shell.NameSpace(file.DirectoryName);
            availabilityStatusIndex = GetAvailabilityStatusIndex(objFolder);
            return objFolder.GetDetailsOf(objFolder.ParseName(file.Name), availabilityStatusIndex);
        }
        public static string OneDriveAvailability(this FileInfo file, int availabilityStatusIndex)
        {
            Shell shell = new Shell();
            Folder objFolder = shell.NameSpace(file.DirectoryName);
            FolderItem objFolderItem = objFolder.ParseName(file.Name);
            return objFolder.GetDetailsOf(objFolderItem, availabilityStatusIndex);
        }
        public static IEnumerable<OneDriveFileInfo> OneDriveAvailability(this DirectoryInfo directory,Func<DirectoryInfo,IEnumerable<FileInfo>> files)
        {
            var requireIndex = true;
            int availabilityStatusIndex = 0;
            return files(directory).Select(f =>
            {
                string oneDriveAvailability;
                if (requireIndex)
                {
                    requireIndex = false;
                    oneDriveAvailability= f.OneDriveAvailability(out availabilityStatusIndex);
                }
                else
                {
                    oneDriveAvailability= f.OneDriveAvailability(availabilityStatusIndex);
                }
                return new OneDriveFileInfo(oneDriveAvailability, f);
            });
        }
        public static IEnumerable<OneDriveFileInfo> OneDriveAvailability(this IEnumerable<FileInfo> files,int availabilityIndex)
        {
            return files.Select(f => new OneDriveFileInfo(f.OneDriveAvailability(availabilityIndex), f));
        }
    }
    public class OneDriveFileInfo
    {
        public OneDriveFileInfo(string availabilityStatus, FileInfo file)
        {
            this.AvailabilityStatus = availabilityStatus;
            this.File = file;
        }
        public string AvailabilityStatus { get; private set; }
        public FileInfo File { get; private set; }
    }

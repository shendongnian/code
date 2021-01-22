    public sealed class FileList : IEquatable<FileList>
    {
        private readonly string fileNames;
        public string FileNames { get { return fileNames; } }
   
        public FileList(string fileNames)
        {
            // If you want to allow a null FileNames, you'll need to change
            // the code in a few places
            if (fileNames == null)
            {
                throw new ArgumentNullException("fileNames");
            }
            this.fileNames = fileNames;
        }
        public override int GetHashCode()
        {
            return fileNames.GetHashCode();
        }
        public override bool Equals(object other)
        {
            return Equals(other as FileList);
        }
        public bool Equals(FileList other)
        {
            return other != null && other.FileNames == FileNames;
        }
    }

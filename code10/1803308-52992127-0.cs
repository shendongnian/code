    public abstract class Record
    {
        public abstract int GetNumberFiles();
    }
    public class FolderRecord : Record
    {
        private int _numberOfFiles;
        public void SetNumberOfFiles(int numberOfFiles)
        {
            _numberOfFiles = numberOfFiles;
        }
        public override int GetNumberFiles()
        {
            return _numberOfFiles;
        }
    }
    public class FileRecord : Record
    {
        public override int GetNumberFiles()
        {
            return 1;
        }
    }

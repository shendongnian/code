    public class SomeClass
    {
        public event EventHandler<FileEventArgs> SomethingHappened;
    }
    public class FileEventArgs : EventArgs
    {
        public FileEventArgs(string filename)
        {
            Filename = filename;
        }
        public string Filename { get; private set; }
    }

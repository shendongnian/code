    /// <summary>
    /// The event args for a selected file.
    /// </summary>
    public class FileSelectedEventArgs : EventArgs 
    {
        public string FileName { get; private set; }
        public FileSelectedEventArgs(string fileName)
        {
            this.FileName = fileName;
        }
    }

    public class Testing
    {
        public void Foo()
        {
            FileInfo[] files = new FileInfo[30];
            // FILL THE FILE ARRAY
            Array.Sort(files, SelectingComparer<FileInfo>.Create(file => file.Name));
            Array.Sort(files, SelectingComparer<FileInfo>.Create(file => file.Name, StringComparer.OrdinalIgnoreCase));
        }
    }

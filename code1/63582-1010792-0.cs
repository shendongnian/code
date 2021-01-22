    public class ManagedFileReader : IManagedFileReader
    {
        public string Read(string path)
        {
            using (StreamReader reader = File.OpenRead(path))
            {
                return reader.ReadToEnd();
            }
        }
    }

    public class IOUtils
    {
        public static void DeleteDirectory(string directory)
        {
            Directory.GetFiles(directory, "*", SearchOption.AllDirectories).ForEach(File.Delete);
            Directory.Delete(directory, true);
        }
    }

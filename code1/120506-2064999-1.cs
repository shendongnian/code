    public abstract class FileBase
    {
    }
    public class File1 : FileBase
    {
    }
    public class Test
    {
        public Dictionary<string, T> ReadFile<T>(string file) where T : FileBase, new()
        {
            Dictionary<string, T> myDictionary = new Dictionary<string, T>();
            myDictionary.Add(file, new T());
            (myDictionary[file] as FileBase).DoSomeParsing();
            return myDictionary;
        }
        public object Testit()
        {
            Test test = new Test();
            return test.ReadFile<File1>("C:\file.txt");
        }
    }

    static T WithStream<T>(string path, Func<FileStream, T> getter)
    {
      using (FileStream stream = File.Open(path, FileMode.Open))
      {
        return getter(stream);
      }
    }
    class MyObject : IDisposable
    {
        public MyObject (Stream stream){ /* Work with stream */}
        public void Dispose(){}
        
    }
    static void Main()
    {
 
        using (MyObject obj = WithStream("path", fs => new MyObject(fs)))
        {
          // do something with obj
        }
    }

    interface IMyDataSource
    {
       // ...
    }
    class FileDataSource: IMyDataSource
    {
        public FileDataSource(string path)
        {
            // ...
        }
    }
    class MyClass
    {
        public MyClass(IMyDataSource source)
        {
             // ...
        }
    }
    IMyDataSource myDS = new FileDataSource(@"C:\temp");
    MyClass myClass = new MyClass(myDS);

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class Class1
    {
        public IMyListOfString Strings {get; set;}
        public Class1()
        {
            Strings = new MyListOfString() { "Foo", "Bar", "Baz" };
        }
    }
    [ComDefaultInterface(typeof(IMyListOfString))]
    public class MyListOfString : List<string>, IMyListOfString { }
    
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IMyListOfString
    {
        [DispId(0)]
        string this[int idx] { get; set; }
    }

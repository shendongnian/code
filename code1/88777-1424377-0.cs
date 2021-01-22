    [Guid("123565C4-C5FA-4512-A560-1D47F9FDFA20")]
    public interface IDoSomething
    {
        [DispId(1)]
        string Name { get; }
    
        [DispId(2)]
        int DoSomething();
    }
    
    [ComVisible(true)]
    [Guid("12AC8095-BD27-4de8-A30B-991940666927")]
    [ClassInterface(ClassInterfaceType.None)]
    public sealed class DoSomething: IDoSomething
    {
        public DoSomething()
        {
        }
    
        public string Name
        {
            get { return ""; }
        }
    
        public int DoSomething()
        {
            return 4; //random number
        }
    }

    // In Windows.dll class library project
    using System.Composition;
    [Export(typeof(IPlatform))]
    public class WindowsImpl : IPlatform
    {
        public void DoSomething()
        {
            //...
        }
    }

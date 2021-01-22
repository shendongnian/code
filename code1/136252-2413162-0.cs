namespace StructInterfaceBoxingTest
{
    public struct TestStruct : IDisposable
    {
        #region IDisposable Members
        public void Dispose()
        {
            System.Console.WriteLine("Boo!");
        }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (TestStruct str = new TestStruct())
            {
            }
        }
        static void BoxTest()
        {
            TestStruct str = new TestStruct();
            ThisWillBox(str);
        }
        static void ThisWillBox(object item) {}
    }
}

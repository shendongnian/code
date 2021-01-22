    [ComVisible(true)]
    [Guid("694C1820-04B6-4988-928F-FD858B95C881")]
    public interface ITestWPFInterface
    {
        [DispId(1)]
        void TestWPF();
    }
    
    [ComVisible(true)]
    [Guid("9E5E5FB2-219D-4ee7-AB27-E4DBED8E123F"),
    ClassInterface(ClassInterfaceType.None)]
    public class TestWPFInterface : ITestWPFInterface
    {
        public void TestWPF()
        {
            Window1 form = new Window1();
            form.Show();
        }
    }

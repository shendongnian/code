    public class MyClass
    {
        private IDataHelper helper;
        public MyClass(IDataHelper helper)
        {
            this.helper = helper;
        }
        public void DoSomething()
        {
            helper.ExecuteNonQuery("some sql");
        }
    }

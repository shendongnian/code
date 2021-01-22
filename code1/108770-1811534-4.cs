    public class MyClass
    {
        public void DoSomething()
        {
            var helper = DataHelperFactory.Create();
            helper.ExecuteNonQuery("some sql");
        }
    }

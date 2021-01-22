    public enum TestEnum
    {
        Bar,
        Test
    }
    public class Test
    {
        public void Test()
        {
            TestEnum foo = "Test".EnumParse<TestEnum>();
        }
     }

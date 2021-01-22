    public class Class1
    {
        public List<string> list = new List<string>() { "test", "test1", "test2" };
    
    	public void test_lambda()
        {
            var test = list.Where(l => l == "test1");
        }
    
        public void test_linq()
        {
            var test = from l in list
                       where l == "test2"
                       select l;
        }
    }

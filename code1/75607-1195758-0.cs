    public class MyClassInstance
    {
        public int MyProperty { get; set; }
    
        public MyClassInstance(int prop)
        {
            MyProperty = prop;
        }
    
        public void IncrementInstance()
        {
            MyProperty++;
        }
    }
    
    public static class MyClassStatic
    {
        public static void IncrementStatic(this MyClassInstance i)
        {
            i.MyProperty++;
        }
    }

    /// <summary>
    /// This text should automatically show up as the summary when hovering over
    /// an instance of this class in VS
    /// </summary>
    public class MyClass
    {
        public MyClass() {}      
    }
    public class MyClass2
    {
        public MyClass()
        {
            //hovering over 'something' below in VS should provide the summary tooltip...
            MyClass something = new MyClass();
        }
    }

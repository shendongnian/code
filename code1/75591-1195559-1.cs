    public class Class12 : I1, I2
    {
        public int NumberOne { get; set; }
        public int NumberTwo { get; set; }
    }
    public class TestClass
    {
        public void Test1()
        {
            Class12 z = new Class12();
            EitherInterface.DoSomething<Class12>((I1)z);
            EitherInterface.DoSomething<Class12>((I2)z);
        }
    }

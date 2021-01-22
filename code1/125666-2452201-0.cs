    public class A
    {
        public A() { }
    
        public string AccessData(object accessor)
        {
            if (accessor is B)
                return "private_data";
            else
                throw new UnauthorizedAccessException();
        }
    }
    
    public class B
    {
        public B() { }
    
        private void AccessDataFromA()
        {
            Console.WriteLine(new A().AccessData(this));
        }
    }

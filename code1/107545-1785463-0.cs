    public class Test<T> where T : struct
    {
        T? _value;
    
        public void Test(T? value)
        {
            _value = value;
        }
    
        public void DoStuff()
        {
            if(_value.HasValue)
            {
                //stuff
            }
        }
     }

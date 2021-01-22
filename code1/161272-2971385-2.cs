    public class MyClass
    {
        static readonly object _sync = new object();
        static string _myResource = "";
        static volatile bool _init = false;
    
        public MyClass()
        {
            if (_init == true) return;
            lock (_sync)
            {
                if (_init == true) return;
                Thread.Sleep(3000); // some operation that takes a long time 
                _myResource = "Hello World";
                _init = true;
            }
        }
    
        public string MyResource 
        { 
            get 
            { 
                MyClass ret; // Correct
                lock(_sync)
                {
                    ret = _myResource;
                }
                return ret;
            } 
        }
    }

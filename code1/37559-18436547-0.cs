    class MyObj
    {
        public void implicit_null_comparison_demo()
        {
            MyObj mo = null;
            // ...
    
            if (mo)			//  <-- like so (can also use !mo)
            {
                // it's not null...
            }
            else
            {
                // it's null...
            }
        }
        public static implicit operator bool(MyObj mo)
        {
            return (Object)mo != null;
        }
    };

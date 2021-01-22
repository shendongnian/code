    class Foo
    {
        private static IBar _bar;
    
        static Foo()
        {
            if(something)
            {
                _bar = new BarA();
            }
            else
            {
                _bar = new BarB();
            }
        }
    }

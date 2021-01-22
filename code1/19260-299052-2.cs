    interface IFooable
    {
        public void Foo();
    }
    
    class A : IFooable
    {
        //other methods ...
    
        public void Foo()
        {
            this.Hop();
        }
    }
    
    class B : IFooable
    {
        //other methods ...
    
        public void Foo()
        {
            this.Skip();
        }
    }
    
    class ProcessingClass
    {
        public void Foo(object o)
        {
            if (o == null)
                throw new NullRefferenceException("Null reference", "o");
    
            IFooable f = o as IFooable;
            if (f != null)
            {
                f.Foo();
            }
            else
            {
                throw new ArgumentException("Unexpected type: " + o.GetType());
            }
        }
    }

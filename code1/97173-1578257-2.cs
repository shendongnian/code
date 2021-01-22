    class Foo 
    {
        // ...
        public Foo ConcreteFoo()
        {
            if (this.GetType().Equals(typeof(Foo)))
                return this;
            else
            {
                Foo f = new Foo();
                // clone properties
                return f;
            }
        }
    }

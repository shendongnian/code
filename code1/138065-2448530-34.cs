    // your subscribing class
    class Bar
    {      
        Foo f;
 
        public Bar()
        {
            f = new Foo();
            f.Changed += Foo_Changed;    // Subscribe, using the short notation
        }
        void Foo_Changed(object sender, EventArgs args)  // the Handler (reacts)
        {
            // the things Bar has to do when Foo changes
        }
    }

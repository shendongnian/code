    class Bar
    {      
        Foo f;
 
        public Bar()
        {
            f = new Foo();
            f.Changed += OnFooChanged;    // Subscribe
        }
        void OnFooChanged(object sender, EventArgs args)  // the Handler (reacts)
        {
            // the things Bar has to do when Foo changes
        }
    }

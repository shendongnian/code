    class Bar
    {      
        Foo f  new Foo();
 
        void Setup()
        {
            f.Changed += OnFooChanged;    // Subscribe
        }
        void OnFooChanged(object sender, EventArgs args)  // the Handler (reacts)
        {
            // the things Bar has to do when Foo changes
        }
    }

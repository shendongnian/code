    class Bar
    {       
        void Setup()
        {
            Foo f = ....
            f.Changed += OnFooChanged;    // Subscribe
        }
        void OnFooChanged(object sender, EventArgs args)  // the Handler (reacts)
        {
            // the things Bar has to do when Foo changes
        }
    }

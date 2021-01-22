    // your subscribing class
    class Bar
    {       
        public Bar()
        {
            Foo f = new Foo();
            f.Changed += Foo_Changed;    // Subscribe, using the short notation
        }
        // the handler must conform to the signature
        void Foo_Changed(object sender, EventArgs args)  // the Handler (reacts)
        {
            // the things Bar has to do when Foo changes
        }
    }

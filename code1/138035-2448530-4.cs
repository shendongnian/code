    class Bar
    {
        void OnFooChanged(object sender, EventArgs args)  // the Handler (reacts)
        {
            //
        }
        void Setup()
        {
            Foo f = ....
            f.Changed += OnFooChanged;    // Subscribe
        }
    }

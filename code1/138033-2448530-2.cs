    class Bar
    {
        void OnFooChanged(obkect sender, EventArgs args)  // handle (react)
        {
            //
        }
        void Setup()
        {
            Foo f = ....
            f.Changed += OnFooChanged;  // subscribe
        }
    }

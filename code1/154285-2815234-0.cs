        class Bar
        {
            public Bar(Foo l)
            {
                _holdAnEvent = l_AnEvent;
                l.AnEvent += _holdAnEvent;
            }
            Action<int> _holdAnEvent;
            ...
        }

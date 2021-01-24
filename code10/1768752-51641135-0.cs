        int? _fooBacking = null;
        int Foo
        {
            get
            {
                if (!_fooBacking.HasValue)
                {
                    _fooBacking = 5;
                }
                return _fooBacking.Value;
            }
            set
            {
                _fooBacking = value;
            }
        }

        private MyClass _MC;
        private MyClass MC
        {
            get
            {
                if(_MC == null)
                {
                    _MC = new MyClass();
                }
                return _MC;
            }
        }

        public ReadOnlyIndexedProperty<int, T> ExampleProperty
        {
            get
            {
                return new ReadOnlyIndexedProperty<int, T>(GetIndex);
            }
        }

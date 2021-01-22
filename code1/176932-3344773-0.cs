    class Test
        {
            private List<T> index;
            public T this[string name]{ get; set; }
            public T this[int i]
            {
                get
                {
                    return index[i];
                }
                set
                {
                    index[i] = value;
                }
            }
        }

        private List<Type> _list = new List<Type>();
        
        public void Add<TAdd>() where TAdd : T
        {
            _list.Add(typeof(TAdd));
        }
        
        public IEnumerator<Type> GetEnumerator() => _list.GetEnumerator();
        
        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
    }

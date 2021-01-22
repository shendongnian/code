        public IEnumerable<int> MyList
        {
            get { return _myList.AsEnumerable<int>(); }
        }
        // or like this:
        public IEnumerable<int> MyList
        {
            get { return (IEnumerable<int>) _myList; }
        }

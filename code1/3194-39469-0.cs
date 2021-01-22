    class EvenList: IList
    {
        private IList innerList;
        public EvenList(IList innerList)
        {
             this.innerList = innerList;
        }
        public object this[int index]
        {
            get { return innerList[2*i]; }
            set { innerList[2*i] = value; }
        }
        // and similarly for the other IList methods
    }

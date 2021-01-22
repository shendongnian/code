    class Indexers
    {
        private Int16[] RollNumberVariable;
        public Indexers(Int16 size)
        {
            RollNumberVariable = new Int16[size];
            for (int i = 0; i < size; i++)
            {
                RollNumberVariable[i] = 0;
            }
        }
        public Int16 this[int pos]
        {
            get
            {
                return RollNumberVariable[pos];
            }
            set
            {
                RollNumberVariable[pos] = value;
            }
        }
    }
}

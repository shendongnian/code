    public class PersonCollection : IEnumerable
    {
        private ArrayList alPers = new ArrayList();
        public IEnumerator GetEnumerator() { return new myTypeEnumerator(this); }
        public class myTypeEnumerator : IEnumerator
        {
            int nIndex;
            PersonCollection pers;
            private int count { get { return pers.alPers.Count; } }
            public myTypeEnumerator(PersonCollection myTypes) 
             { pers = myTypes; nIndex = -1; }
            public bool MoveNext() { return nIndex <= count && ++nIndex < count; }
            // MovePrev() not strictly required
            public bool MovePrev() { return (nIndex > -1 && --nIndex > 0 ); }
            public object Current { get { return (pers[nIndex]); } }
            public void Reset() { nIndex = -1; }
        }
    }

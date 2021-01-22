    public clas SomeClass : IEnumerable<SomeOtherClass>
    {
        public IEnumerator<SomeOtherClass> GetEnumerator ()
        {
            ...
        }
        IEnumerator IEnumerable.GetEnumerator ()
        {
            return GetEnumerator ();
        }
    }

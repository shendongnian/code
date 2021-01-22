    class Test
    {
        public SomethingEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    class SomethingEnumerator
    {
        public Something Current //could return anything
        {
            get { throw new NotImplementedException(); }
        }
        public bool MoveNext()
        {
            throw new NotImplementedException();
        }
    }
    //now you can call
    foreach (Something thing in new Test()) //type safe
    {
    }

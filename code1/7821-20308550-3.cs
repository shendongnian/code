    class Test
    {
        public SomethingEnumerator GetEnumerator()
        {
        }
    }
    class SomethingEnumerator
    {
        public Something Current //could return anything
        {
            get { }
        }
        public bool MoveNext()
        {
        }
    }
    //now you can call
    foreach (Something thing in new Test()) //type safe
    {
    }

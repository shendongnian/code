    class MyTypeList : IList<MyType>
    {
        private List<MyType> internalList = new ...;
        public bool Contains(MyType instance)
        {
        }
        ....
    }

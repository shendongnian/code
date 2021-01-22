    class A
    {
        private List<SomeClass> list;
        private readonly object listLock = new object();
    
        private void ClearList()
        {
            lock (listLock)
            {
                list = new List<SomeClass>();
            }
        }
    
        private void AddElement()
        {
            lock (listLock)
            {
                list.Add(new SomeClass(...));
            }
        }
        private List<SomeClass> CopyList()
        {
            lock (listLock)
            {
                return new List<SomeClass>(list);
            }
        }
    }

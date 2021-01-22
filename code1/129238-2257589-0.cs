    class A
    {
        static object myLock = new object()
        List<SomeClass> list;
    
        private void clearList()
        {
            lock(myLock)
            {
              list = new List<SomeClass>();
            }
        }
    
        private void addElement()
        {
            lock(myLock)
            {
              list.Add(new SomeClass(...));
            }
        }
    }

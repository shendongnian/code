    class MyComparer : IComparer<YourClass> {
        private MyComparer() { }
        public static readonly MyComparer Instance = new MyComparer();
        public int CompareTo(YourClass a, YourClass b) {
            //TODO: Handle nulls
            return a.SomeProperty.CompareTo(b.SomeProperty);
        }
    }
    foreach(var item in list1) {
        if (list2.BinarySearch(item, MyComparer.Instance) >= 0) {
            //Do something
        }
    }

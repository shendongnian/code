    class MyComparer : IEqualityComparer<MyClass>
    {
        public bool Equals(MyClass x, MyClass y)
        {
            return x.id == y.id;
        }
        public int GetHashCode(MyClass item)
        {
            return item.id.GetHashCode();
        }
    }
    relatedList = relatedList.Union(baseList.SelectMany(baseItem => GetRelatedItems(baseItem)), new MyComparer());

    var list3 = list2.Except(list1, new MyComparer());
    
    class MyComparer : IEqualityComparer<MyElementType>
    {
        public bool Equals(MyElementType x, MyElementType y)
        {
            return x.MyProperty == y.MyProperty;
        }
        public int GetHashCode(MyElementType e)
        {
            return e.MyProperty.GetHashCode();
        }
    }

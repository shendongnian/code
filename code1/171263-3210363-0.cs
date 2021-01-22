    static private int SortStrings(MyClass a, MyClass b) {
        return a.GetValue().CompareTo(b.GetValue());
    }
    public Comparison<MyClass> GetCompareFunction() {
        return SortStrings; // or whatever
    }
    ...
    elements.Sort(datatype.GetCompareFunction()); 

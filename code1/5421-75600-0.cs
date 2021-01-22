    public class MyListBase<T> : IEnumerable<T> where T : ItemBase
    {
    }
            
    public class MyItem : ItemBase
    {
    }
            
    public class MyDerivedList : MyListBase<MyItem>
    {
    }

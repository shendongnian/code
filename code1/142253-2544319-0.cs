    public class GenericClass<T> where T : GenericListItem
    {
        private List<T> _listItems;
    }
    public class SpecificClass : GenericClass<SpecificListItem>
    {
        // ...
    }

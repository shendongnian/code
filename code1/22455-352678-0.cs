    using System.Collections.ObjectModel;
    ...
    public MyClass(..., List<ListItemType> theList, ...)
    {
        ...
        this.myListItemCollection= theList.AsReadOnly();
        ...
    }
    public ReadOnlyCollection<ListItemType> ListItems
    {
         get { return this.myListItemCollection; }
    }

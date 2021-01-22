    public interface ISortable
    {
        // ... whatever you need to make a class sortable
    }
    public class ExistingType
    {
        // whatever
    }
    public class NewType : ExistingType, ISortable
    {
        // ...
    }

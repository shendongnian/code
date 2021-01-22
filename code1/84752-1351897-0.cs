    public class MyList<T> : IList<T>
    {
        ...
    }
    
    public class MyDisplayableList<T> : MyList<T> where T : IDisplayable
    {
        ...
    }

    public delegate IEnumerable<T> ChildrenDel<T>( T parent);
    
    public static IEnumerable< T > GetDescendants<T>( this T item, ChildrenDel<T> children )
    {
        var stack = new Stack< T >();
        do {
            children( item ).ForEach( stack.Push );
    
            if( stack.Count == 0 )
                break;
    
            item = stack.Pop();
    
            yield return item;
        } while( true );
    }

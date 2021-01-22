    public static class ExtensionMethods
    {
        // Enumerate all descendants of the argument,
        // but not the argument itself:
        public static IEnumerable<T> Traverse<T>( this T item, 
                                         Func<T, IEnumerable<T>> selector )
        {
            return Traverse<T>( selector( item ), selector );
        }
        
        // Enumerate each item in the argument and all descendants:
        public static IEnumerable<T> Traverse<T>( this IEnumerable<T> items, 
                                            Func<T, IEnumerable<T>> selector )
        {
            if( items != null )
            {
                foreach( T item in items )
                {
                    yield return item;
                    foreach( T child in Traverse<T>( selector( item ), selector ) )
                        yield return child;
                }
            }
        }
    }           
    // Example using System.Windows.Forms.TreeNode:
    TreeNode root = myTreeView.Nodes[0];
    foreach( string text in root.Traverse( n => n.Nodes ).Select( n => n.Text ) )
       Console.WriteLine( text );
    // Sometimes we also need to enumerate parent nodes
    //
    // This method enumerates the items in any "implied"
    // sequence, where each item can be used to deduce the
    // next item in the sequence (items must be class types
    // and the selector returns null to signal the end of
    // the sequence):
    public static IEnumerable<T> Walk<T>( this T start, Func<T, T> selector )
        where T: class
    {
        return Walk<T>( start, true, selector )
    }
    // if withStart is true, the start argument is the 
    // first enumerated item in the sequence, otherwise 
    // the start argument item is not enumerated:
    public static IEnumerable<T> Walk<T>( this T start, 
                                          bool withStart, 
                                          Func<T, T> selector )
        where T: class
    {
        if( start == null )
            throw new ArgumentNullException( "start" );
        if( selector == null )
            throw new ArgumentNullException( "selector" );
        T item = withStart ? start : selector( start );
        while( item != null )
        {
            yield return item;
            item = selector( item );
        }
    }
    // Example: Generate a "breadcrumb bar"-style string
    // showing the path to the currently selected TreeNode
    // e.g., "Parent > Child > Grandchild":
    TreeNode node = myTreeView.SelectedNode;
    
    var text = node.Walk( n => n.Parent ).Select( n => n.Text );
   
    string breadcrumbText = string.Join( " > ", text.Reverse() );
   
    

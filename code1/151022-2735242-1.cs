    public static IEnumerable<T> Descendants<T>( this Control control ) where T : class
    {
        foreach ( Control child in control.Controls ) {
            T childOfT = child as T;
            if ( childOfT != null ) {
                yield return (T)childOfT;
            }
            if ( child.HasChildren ) {
                foreach ( T descendant in Descendants<T>( child ) ) {
                    yield return descendant;
                }
            }
        }
    }

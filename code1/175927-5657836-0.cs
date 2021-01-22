    public void Add( MyDelegate<T> del ) {
        imp.Add( del );
    }
    public void CallDelegates( T k ) {
        foreach( MyDelegate<T> del in imp ) {
            del( k );
        }
    }
    private List<MyDelegate<T> > imp = new List<MyDelegate<T> >();

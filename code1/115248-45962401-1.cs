    /*  Where __strBuf is a string list used as a dumping ground for data  */
    public List < string > pullStrLst( )
    {
        List < string > lst;
        lst = __strBuf.GetRange( 0, __strBuf.Count );     
            
        __strBuf.Clear( );
        return( lst );
    }

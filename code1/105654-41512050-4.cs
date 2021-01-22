    public static bool IsNumeric<T>( this T myType )
    {
        var IsNumeric = false;
        if( myType != null )
        {
            IsNumeric = m_numTypes.Contains( myType.GetType() );
        }
        return IsNumeric;
    }

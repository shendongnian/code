    [WebMethod]
    public static void ToggleLockedStatus ( string key )
    {
        if ( BusinessObjectDictionary.ContainsKey( key ) )
        {
            BusinessObjectDictionary[ key ].Locked = !BusinessObjectDictionary[ key ].Locked;
        }
        else
        {
            throw new Exception( "The business object specified was not found." );
        }
    }

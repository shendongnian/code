    VisitGroups( _groups[_parentGroupName], "" );
    void VisitGroups( string ID, string indent )
    {
       IGroup x;
       if( _groups.TryGetValue( ID, out x ) )
       {
           foreach( IGroup y in x.Groups )
           {
              WriteLine( indent + " {0}", y.ID );
              VisitGroups( y.ID, indent + "   " );
           }        
       }
    }

    void BuildGroups()
    {
       foreach( IGroup x /* obtained from database or a collection or wherever */ )
          AddGroup( x );
    }
    Dictionary<string,IGroup> _groups = new Dictionary<string,IGroup>;
    string _parentGroupName = "PARENT";
    void AddGroup( IGroup x )
    {
        // locate (or create) parent and add incoming group
        IGroup parent;
        string parentID = x.ParentID ?? _parentGroupName;
        if( !groups.TryGetValue( parentID, out parent ) )
        {
           parent = new Group( parentID ); // SEE NOTE BELOW!
           _groups[parentID] = parent;
        }
        parent.Groups.Add( x );
        // locate (or insert) child, and make sure it's up to date
        IGroup child;
        if( groups.TryGetValue( x.ID, out child ) )
        {
           // We must have inserted this ID before, because we found one
           // of ITS children first.  If there are any other values besides
           // ParentID and ID, then copy them from X to child here.
        }
        else
        {
           // first time we've seen this child ID -- insert it
            _groups[x.ID] = x;
        }
    }

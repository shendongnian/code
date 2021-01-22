    class Node
    {
        string _cachedParentType = null;
        string _type;
        string Type 
        {
            get { return _type ?? _cachedParentType ?? (_cachedParentType = Parent.Type); }
            set 
            { 
                _type = value; 
                foreach (var child in Children) { child._cachedParentType = null; }
            }
        }
    }

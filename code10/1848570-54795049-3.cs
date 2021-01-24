    public string GetPath()
    {
        System.Text.StringBuilder sb = new StringBuilder();
        Categories current = this;
        while( current != null)
        {
            sb.Insert(0,current.Name);        
            if( current != this)
            {
               sb.Insert(0,@\");        
            }
            current = Parent;
        }
        return sb.ToString();
    }

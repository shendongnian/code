    public ArrayList RemoveDups ( ArrayList input )
    {
        ArrayList single_values = new ArrayList();
    
        foreach( object item in input)
        {
            if( !single_values.Contains(item) )
            {
                single_values.Add(item);
            }
        }
        return single_values;
    }

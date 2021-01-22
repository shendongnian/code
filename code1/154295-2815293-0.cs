    public IDataNode<DataType> FindNode<DataType>(DataType dt)
    {
        IDataNode<DataType> result = null;
        foreach (var child in Children)
        {
            if (child is IDataNode<DataType>)
            {
                var datachild = child as IDataNode<DataType>;
                if (datachild.Data.Equals(dt))
                {
                    result = child as IDataNode<DataType>;
                    break;
                }
            }
            else 
            {
                 // it's not a DataType You're looking for, so ignore it!
            }
       }
       return result; 
    }

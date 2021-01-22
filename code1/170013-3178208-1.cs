    public List<object> CreateListCopy()
    {
        List<object> result = new List<object>();
        lock(_list)
        {
            foreach(object o in _list)
            {
                result.Add(o.Clone());
            }
        }
    
        return result;
    }

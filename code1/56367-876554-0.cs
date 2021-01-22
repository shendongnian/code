    private bool AreEqual<T>(List<T> x, List<T> y)
    {
        // same list or both are null
        if (x == y)
        {
            return true;
        }
    
        // one is null (but not the other)
        if (x== null || y == null)
        {
            return false;
        }
    
        // count differs; they are not equal
        if (x.Count != y.Count)
        {
            return false;
        }
    
        for (int i = 0; i < x.Count; i++)
        {
            if (!x[i].Equals(y[i]))
            {
                return false;
            }
        }
        return true;
    }

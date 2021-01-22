    public override bool Equals(Customer x, Customer y)
    {
        if (object.ReferenceEquals(x, y))
        {
            return true;
        }
        if (x == null || y == null)
        {
            return false;
        }
        return x.Id == y.Id && x.Name == y.Name;
    }

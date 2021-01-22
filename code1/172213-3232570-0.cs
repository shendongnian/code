    public void Eat(IEnumerable<Slice> remove)
    {
        foreach (Slice r in remove)
        {
            Pizza.Remove(r);
        }
    }

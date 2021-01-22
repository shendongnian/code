    public Estado[] GetSomeOtherMore(int[] values)
    {
        var result = _context.Estados.WhereIn(args => args.Id, values) ;
        return result.ToArray();
    }

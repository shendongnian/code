    public static eRat Previous(this eRat target)
    {
        var nextValueQuery = Enum.GetValues(typeof(eRat)).Cast<eRat>().Reverse().SkipWhile(e => e != target).Skip(1);
        if (nextValueQuery.Count() != 0)
        {
            return (eRat)nextValueQuery.First();
        }
        else
        {
            return eRat.D;
        }
    }

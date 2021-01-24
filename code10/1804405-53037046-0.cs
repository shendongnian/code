    public int Compare(Bonus x, Bonus y)
    {
    	if (x.ID == y.ID) return 0;
        return Math.Sign(x.Number - y.Number);
    }

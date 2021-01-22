    public IEnumerable getdays()
    {
        foreach (string day in days)
    	{
            yield return day;
        }
    }

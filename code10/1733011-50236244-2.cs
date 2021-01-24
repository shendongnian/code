    public static decimal ImportoMin(Mutui[] ele, int n)
    {
        if(ele == null)
        {
            throw new ArgumentNullException(nameof(ele));
        }
        if(n <= 0)
        {
            throw new ArgumentException("Must be greater than zero", nameof(n));
        }
        if(ele.Length == 0)
        {
            // Whatever for handling an empty array.
        }
        return ele.Take(n).Min(x => x.Importo);
    }

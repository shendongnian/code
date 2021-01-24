    public GameObject yourGoWithAboveClassOnIt;
    void Start()
    {
        oldNumberOfUnits = numberOfUnits;
        for (int i = 0; i < numberOfUnits; i++)
        {
            Instantiate(yourGoWithAboveClassOnIt);
        }
    }

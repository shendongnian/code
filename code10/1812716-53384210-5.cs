    public Transform StairsUnit;
    void Start ()
    {
        oldNumberOfUnits = numberOfUnits;
        for (int i = 0; i < numberOfUnits; i++)
        {
            Unit = new GameObject();
            Unit.name = "Stairs " + i.ToString();
            Unit.SetParent(StairsUnit);
            Unit.AddComponent<GenerateStairs>();
        }
    }

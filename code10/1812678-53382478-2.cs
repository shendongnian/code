    void Start()
    {
        //oldNumberOfUnits = numberOfUnits;
        //for (int i = 0; i < numberOfUnits; i++)
        //{
            stairsParent = new GameObject();
            stairsParent.name = "Stairs";
            StartCoroutine(BuildStairs());
        //}
    }
    

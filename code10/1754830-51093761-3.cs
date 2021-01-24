    public GameObject squadMemeberPrefab;
    List<GameObject> SquadMembers = new List<GameObject>();
    
    void Update()
    {
        if (numofmembers != numberOfSquadMembers)
        {
            numofmembers = numberOfSquadMembers;
            formations.Init(numberOfSquadMembers, columns, gaps);
            GenerateSquad();
        }
    }
    private void GenerateSquad()
    {
        Transform go = squadMemeberPrefab;
        List<GameObject> newSquadMembers = new List<GameObject>();
        int i = 0;
        for (; i < formations.newpositions.Count; i++)
        {
            if (i < SquadMembers.Count)
                go = SquadMembers[i];
            else
            {
                go = Instantiate(squadMemeberPrefab);
                newSquadMembers.Add(go);
            }
            go.position = formations.newpositions[i];
            go.tag = "Squad Member";
            go.transform.parent = gameObject.transform;
        }
        for (; i < SquadMembers.Count; i++)
            Destroy(SquadMembers[i]);
        SquadMembers = newSquadMembers;
    }

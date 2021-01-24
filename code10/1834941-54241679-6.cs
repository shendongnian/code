    private void Start()
    {
        // Get the index of the currently active object in the scene
        // Note: This only gets the first active object
        // so only one should be active at start
        // if none is found than 0 is used
        for(int i = 0; i < dress.Length; i++)
        {
            if(!dress[i].activeInHierachy) continue; 
            _index = i;
        }
        // Or use LinQ to do the same
        _index = dress.FirstOrDefault(d => d.activeInHierarchy);
    }

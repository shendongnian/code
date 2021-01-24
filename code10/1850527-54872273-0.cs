    void Update()
    {
        var items = new Dictionary<string, StrainsManager>
        { 
             { nameof(Ba2), Ba2 },
             { nameof(Ba3), Ba3 },
             { nameof(Ba8), Ba8 },
        };
    
        foreach (var item in items)
        {
            PlayerPrefs.SetFloat($"{item.Key}Cost", item.Value.cost);
            PlayerPrefs.SetFloat($"{item.Key}IPSAdd", item.Value.IPSAdd);
            PlayerPrefs.SetFloat($"{item.Key}Time", item.Value.time);
            PlayerPrefs.SetFloat($"{item.Key}CostMod", item.Value.costMod);
            PlayerPrefs.SetFloat($"{item.Key}InfectMod", item.Value.infectMod);
        }
    };

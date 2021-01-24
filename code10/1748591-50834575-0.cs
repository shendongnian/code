    public GameObject filePrefab; // to be able to instantiate new "files"
    ...
    for (...)
    {
        // Create the file and assign the valuse
        GameObject tempFile = Instantiate( filePrefab);
        Text tempName = tempFile.GetChild(0).GetComponenet<Text>();
        Text tempDescription = tempFile.GetChild(1).GetComponenet<Text>();
        Text tempCurrency1Award = tempFile.GetChild(2).GetComponenet<Text>();
        // Here you can set there position, etc.
        ...
        // Assign the values
        tempName.text = name;
        tempDescription.text = description;
        tempCurrency1Award.text = currency1Award.ToString();  
    }

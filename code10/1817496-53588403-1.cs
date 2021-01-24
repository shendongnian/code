    var searchedTags = new List<string>()
    {
        "WoodBlock",
        "WoodSteps",
        "WoodRamp",
        "GlasBlock",
        "WoodDoor"
    };
    // This list is used to get all GameObject
    // keep track which where active and activate all
    var allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
    // Here we get all BlockController components
    var allBlockObjects = Resources.FindObjectsOfTypeAll<BlockController>();
    // finally we only get BlockControllers with the tags we want
    var objectsOfInterest = allBlockObjects.Where(obj => searchedTags.Contains(obj.gameObject.tag)).ToList();
    Debug.Log("objects total: " + allObjects.Length);
    Debug.Log("block objects: " + allBlockObjects.Length);
    Debug.Log("objects of interest: " + objectsOfInterest.Length);
    // Step 1 keep track which GameObjects where active and activate all
    var objectWasNotActive = new List<GameObject>();
    foreach (var obj in allObjects)
    {
        if(!obj.activeSelf)
        {
            // keep track which objects where not active
            objectWasNotActive.Add(obj);
        }
        // Set all to true
        obj.SetActive(true);
    }
    
    // Step 2 save your BlockControllers with searched tags
    using (StreamWriter write = new StreamWriter(dir + "blocksSave.dat"))
    {
        foreach (var block in objectsOfInterest)
        {  
            // Here you already have components of type BlockController
            // so you don't need to get them 
               
            // SAVE
                write.WriteLine(
                    block.gameObject.tag + "," 
                    + block.transform.position.x + "," 
                    + block.transform.position.y + "," 
                    + block.transform.position.z + "," 
                    + block.GetHealth().x + "," 
                    + block.GetHealth().y + "," 
                    + block.transform.rotation.x + "," 
                    + block.transform.rotation.y + "," 
                    + block.transform.rotation.z
                );
            }
        }
    }
    // Step 3 disable those GameObjects again that where not active before
    foreach(var obj in objects practice)
    {
        obj.SetActive(false);
    }

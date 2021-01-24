    public GameObjectSpawner Spawner;
    private void Start()
    {
        // You can place this anywhere you want to, but we're
        // placing this here in Start just to make sure that
        // we're already listening waaay before the gameobject
        // is instantiated.
        Spawner.AddListener(CheckHierarchy)
    }
    // It doesn't matter if this is public or private,
    // as long as it's void and takes in a GameObject as a parameter.
    private void CheckHierarchy(GameObject go)
    {
        // Now we can do all kinds of things to the newly instantiated
        // gameobject, like check if it's active in the hierarchy!
        if (go.activeInHierarchy == true)
        {
            Debug.Log("I LIVE!!!");
        }
    }

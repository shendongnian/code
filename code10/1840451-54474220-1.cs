    // Here you store the reference from
    // Assetbundle.LoadAsset
    private object loadedAsset; 
    // Here you store the reference to the assets instance itself
    private GameObject assetInstance;
    
    public void LoadAsstBundles(int choice)
    {
        // Is _assetBundle available?
        if (!_assetsBundle)
        {
            Debug.Log("Could Not load AssetBundles");
            return;
        }  
    
        // Was the bundle loaded before?
        if (!loadedAsset)
        {
            loadedAsset = _assetsBundle.LoadAsset(_assetname);
            
            if(!loadedAsset)
            {
                Debug.LogError("unable to load asset");
                return;
            }
            
            Debug.Log("Asset Bundles Loaded");
        }
    
        // Is the object Instantiated in the scene?
        if(!assetInstance)
        {
            assetInstance = (GameObject)Instantiate(loadedAsset, ParentTransform);
        }
    
        // no need to go by names
        // simply get the correct child by index
        var selected = assetInstance.transform.GetChild(choice);
    
        // Enable or disable the childs
        foreach(Transform chair in assetInstance.transform)
        {
            chair.gameObject.SetActive(chair == selected);
        }
    }

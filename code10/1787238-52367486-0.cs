    public Image image;
    
    string nameOfAssetBundle = "animals";
    string nameOfObjectToLoad = "dog";
    
    void Start()
    {
        StartCoroutine(LoadAsset(nameOfAssetBundle, nameOfObjectToLoad));
    }
    
    IEnumerator LoadAsset(string assetBundleName, string objectNameToLoad)
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "AssetBundles");
        filePath = System.IO.Path.Combine(filePath, assetBundleName);
    
        //Load "animals" AssetBundle
        var assetBundleCreateRequest = AssetBundle.LoadFromFileAsync(filePath);
        yield return assetBundleCreateRequest;
    
        AssetBundle asseBundle = assetBundleCreateRequest.assetBundle;
    
    
        //Load the "dog" Asset (Use Sprite since it's a Sprite. Use GameObject if prefab)
        AssetBundleRequest asset = asseBundle.LoadAssetWithSubAssetsAsync<Sprite>(objectNameToLoad);
        yield return asset;
    
        //Retrive all the Object atlas and store them in loadedSprites Sprite
        UnityEngine.Object[] loadedAsset = asset.allAssets as UnityEngine.Object[];
        Sprite[] loadedSprites = new Sprite[loadedAsset.Length];
        for (int i = 0; i < loadedSprites.Length; i++)
            loadedSprites[i] = (Sprite)loadedAsset[i];
    
        Debug.Log("Atlas Count: " + loadedSprites.Length);
        for (int i = 0; i < loadedSprites.Length; i++)
        {
            Debug.LogWarning(loadedSprites[i].name);
    
            //Do something with the loaded loadedAsset  object (Load to Image component for example) 
            image.sprite = loadedSprites[i];
        }
    }

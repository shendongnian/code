    public GameObject contentRef;
    public RawImage imgPrefab;
    List<Texture2D> downloadedTextures = new List<Texture2D>();
    void Start()
    {
        DownloadtheFiles();
    }
    public void DownloadtheFiles()
    {
        List<string> photolist = ES2.LoadList<string>("myPhotos.txt");
        //Used to determine when were done downloading
        bool[] doneDownloading = new bool[photolist.Count];
        //Download images only.Don't instantiate anything
        for (int i = 0; i < photolist.Count; i++)
        {
            //Don't capture i variable
            int index = i;
            new GetUploadedRequest()
                .SetUploadId(photolist[index])
                .Send((response) =>
                {
                    StartCoroutine(DownloadImages(response.Url, index, doneDownloading));
                    return null;
                });
        }
        //Instantiate the download images
        StartCoroutine(InstantiateImages(doneDownloading));
    }
    //Instantiates the downloaded images after they are done downloading
    IEnumerator InstantiateImages(bool[] downloadStatus)
    {
        //Wait until all images are done downloading
        for (int i = 0; i < downloadStatus.Length; i++)
        {
            while (!downloadStatus[i])
                yield return null;
        }
        //Sort the images by string
        sort(ref downloadedTextures);
        //Now, instantiate the images
        for (int i = 0; i < downloadedTextures.Count; i++)
        {
            //Instantiate the image prefab GameObject and make it a child of the contentRef
            RawImage newImg = Instantiate(imgPrefab, contentRef.transform);
            //Apply the downloaded image
            newImg.texture = downloadedTextures[i];
            //Update name so that we can see the names in the Hierarchy
            newImg.name = downloadedTextures[i].name;
        }
        //Clear List for next use
        downloadedTextures.Clear();
    }
    //Sort the downloaded Textures by name
    void sort(ref List<Texture2D> targetList)
    {
        var ordered = targetList.Select(s => new { s, Str = s.name, Split = s.name.Split('-') })
        .OrderBy(x => int.Parse(x.Split[1]))
        .ThenBy(x => x.Split[0])
        .Select(x => x.s)
        .ToList();
        targetList = ordered;
    }
    public IEnumerator DownloadImages(string downloadUrl, int index, bool[] downloadStatus)
    {
        //Download image
        var www = new WWW(downloadUrl);
        yield return www;
        //Get the downloaded image and add it to the List
        Texture2D tex = new Texture2D(4, 4);
        //Change the name
        tex.name = "Image-" + index;
        www.LoadImageIntoTexture(tex);
        downloadedTextures.Add(tex);
        downloadStatus[index] = true;
    }

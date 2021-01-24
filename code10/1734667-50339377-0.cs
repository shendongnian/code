    public GameObject contentRef;
    public RawImage imgPrefab;
    void Start()
    {
        DownloadtheFiles();
    }
    public void DownloadtheFiles()
    {
        List<string> photolist = ES2.LoadList<string>("myPhotos.txt");
        for (int i = 0; i < photolist.Count; i++)
        {
            //Don't capture i variable
            int index = i;
            new GetUploadedRequest()
                .SetUploadId(photolist[index])
                .Send((response) =>
                {
                    StartCoroutine(DownloadImages(response.Url, index));
                });
        }
    }
    public IEnumerator DownloadImages(string downloadUrl, int index)
    {
        var www = new WWW(downloadUrl);
        yield return www;
        //Instantiate the image prefab GameObject and make it a child of the contentRef
        RawImage newImg = Instantiate(imgPrefab, contentRef.transform);
        //Change the name
        newImg.name = "Image-" + index;
        //Get the downloaded image
        Texture2D tex = new Texture2D(4, 4);
        www.LoadImageIntoTexture(tex);
        //Apply the downloaded image
        newImg.texture = tex;
    }

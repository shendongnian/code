    public SpriteRenderer MySprite;
    private Sprite LoadedSprite = null;
    private void myLoadGameData() //LOAD THE DATA
    {
        string myfilePath = Path.Combine(Application.streamingAssetsPath, mygameDataFileName); //I THINK THIS IS THE PATH OF THE FILE
        if (File.Exists(myfilePath))
        {
            string mydataAsJson = File.ReadAllText(myfilePath); // READ THE FILE
            TSGameData myloadedData = JsonUtility.FromJson<TSGameData>(mydataAsJson);  // TSGAME DATA IS A ANOTHER SCRIPT THAT HAVE AN ARRAY FOR THE DATA
            myRoundData = myloadedData.myRoundData;
            // vvv   CALL OUR NEW METHOD HERE   vvv
            LoadSprite(myRoundData.questionImage);
        } //myRoundData IS A VARIABLE THAT HOLDS THE ARRAY OF TSROUNDDATA TO GET THE DATA
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }
    private void LoadSprite (string path)
    {
        if (LoadedSprite != null)
            Resources.UnloadAsset(LoadedSprite);
        LoadedSprite = Resources.Load<Sprite>(path);
        MySprite.sprite = LoadedSprite;
    }

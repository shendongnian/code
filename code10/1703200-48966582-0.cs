    private List<GameObject> QuestionImageObjects = new List<GameObject>();
    private void myLoadGameData() //LOAD THE DATA
    {
        string myfilePath = Path.Combine(Application.streamingAssetsPath, mygameDataFileName); //I THINK THIS IS THE PATH OF THE FILE
        if (File.Exists(myfilePath))
        {
            string mydataAsJson = File.ReadAllText(myfilePath); // READ THE FILE
            TSGameData myloadedData = JsonUtility.FromJson<TSGameData>(mydataAsJson);  // TSGAME DATA IS A ANOTHER SCRIPT THAT HAVE AN ARRAY FOR THE DATA
            myRoundData = myloadedData.myRoundData;
            CreateImages(myRoundData.questions);
        } //myRoundData IS A VARIABLE THAT HOLDS THE ARRAY OF TSROUNDDATA TO GET THE DATA
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }
    private void CreateImages(List<Question> questions)
    {
        //The two while loops below allow existing image gameobjects to be reused
        
        // Destroy excess images
        while(QuestionImageObjects.Count > questions.Count)
        {
            Destroy(QuestionImageObjects[QuestionImageObjects.Count - 1]);
            QuestionImageObjects.RemoveAt(QuestionImageObjects.Count - 1);
        }
        // Create missing images
        while(QuestionImageObjects.Count < questions.Count)
        {
            GameObject image = new GameObject("Question Image " + QuestionImageObjects.Count);
            image.AddComponent<SpriteRenderer>();
            QuestionImageObjects.Add(image);
        }
        for (int i = 0; i < questions.Count; i++)
        {
            QuestionImageObjects[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(questions[i].questionImage);
        }
    }

     void Start()
    {
        StartCoroutine(GetCrt());
    }
    IEnumerator GetCrt()
    {
        string testURL = "https://www.google.com/";
        using (UnityWebRequest www = UnityWebRequest.Get(testURL))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Get Request Completed!");
            }
        }
    }

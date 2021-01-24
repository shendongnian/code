    void Start()
    {
        StartCoroutine(CheckForPaidApp("http://itunes.apple.com/lookup?id=1218822890")); ;
    }
    IEnumerator CheckForPaidApp(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();
        if (uwr.isHttpError || uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            string data = uwr.downloadHandler.text;
            Debug.Log("Received: " + uwr.downloadHandler.text);
            //Serialize to Json
            RootObject jsonObj = JsonUtility.FromJson<RootObject>(data);
            List<Result> resultObj = jsonObj.results;
            //Loop over the result and show the price information
            for (int i = 0; i < resultObj.Count; i++)
            {
                double price = resultObj[i].price;
                Debug.Log("Price = \n" + price);
                if (price > 0.0f)
                {
                    Debug.Log("Its Paid App\n");
                }
                else
                {
                    // show ads here
                }
            }
        }
    }

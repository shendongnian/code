    IEnumerator Start()
    {
        UnityWebRequest wr = UnityWebRequest.Get("http://localhost:55150/api/values");
        yield return wr.SendWebRequest();
        string a = wr.downloadHandler.text;
        Debug.Log(a);
    
        var jsonObject = JSON.Parse(a);
        foreach (var element in jsonObject)
        {
            var elementName = element.Value["name"];
            // do something with elementName 
            Debug.Log(elementName);
        }
    }
    

    public static IEnumerator UrlData(string url)
    {
        Debug.Log("searching the web");
        using (WWW www = new WWW(url))
        {
            yield return www;
            Debug.Log(www.text);
        }
    }

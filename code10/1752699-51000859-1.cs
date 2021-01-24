    public static IEnumerator UrlData(string url, Action<string> result)
    {
        Debug.Log("searching the web");
        using (WWW www = new WWW(url))
        {
            yield return www;
            if (result != null)
                result(www.text);
        }
    }

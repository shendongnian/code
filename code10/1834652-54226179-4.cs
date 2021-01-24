    [WebMethod]
    public static string GetDataFromDB()
    {
        List<Words> WordsSet = Words.GetWords("Business");
        
        return JsonConvert.SerializeObject(WordsSet);
    }

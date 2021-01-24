    [HttpPost]
    [WebMethod]
    public JsonResult LookUpGames(string search)
    {
        string url = "https://api-v3.igdb.com/games?search=" + search + 
            "&fields=name,genres.name,platforms.name,involved_companies.*, involved_companies.company.*,first_release_date,cover.url";
        HttpWebRequest gameRequest = (HttpWebRequest)WebRequest.Create(url);
        gameRequest.Accept = "application/json";
        gameRequest.Headers.Add("user-key", "[MYUSERKEY]");
        WebResponse gameResponse = gameRequest.GetResponse();
        StreamReader sr = new StreamReader(gameResponse.GetResponseStream());
        string responseString = sr.ReadToEnd();
        sr.Close();
        JsonResult jsonResult = Json(new { result = responseString });
        return jsonResult;
    }

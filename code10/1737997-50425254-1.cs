    List<Film> ResultFilm;
    using (WebClient webClient = new System.Net.WebClient())
    {
        var json = webClient.DownloadString("http://www.omdbapi.com/?s=" + filtro + "&apikey=" + ApiKey);
        JToken search = JObject.Parse(json).GetValue("Search");
        ResultFilm = JsonConvert.DeserializeObject<List<Film>>(search.ToString());
    }
    return ResultFilm;

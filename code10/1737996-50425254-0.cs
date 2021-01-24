    List<Film> ResultFilm = new List<Film>();
    using (WebClient webClient = new System.Net.WebClient())
    {
        var json = webClient.DownloadString("http://www.omdbapi.com/?s=" + filtro + "&apikey=" + ApiKey);
        JToken search = JObject.Parse(json).GetValue("Search");
        foreach (var film in search)
        {
            ResultFilm.Add(film.ToObject<Film>());
        }
    }
    return ResultFilm;

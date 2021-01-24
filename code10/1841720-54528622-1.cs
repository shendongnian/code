    public string CreateJoke()
    {
        var request = (HttpWebRequest)WebRequest.Create("https://icanhazdadjoke.com/");
        request.Method = "GET";
        request.Accept = "text/plain";
    
        var jokeResponse = request.GetResponse();
    
        var joke = string.Empty;
    
        using (var sr = new StreamReader(jokeResponse.GetResponseStream()))
        {
           joke = sr.ReadToEnd();
        }
    
        //Console.WriteLine(joke);
        return joke;
    }

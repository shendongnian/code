    WebRequest SiteyeBaglantiTalebi06 = HttpWebRequest.Create("https://www.somesite.com/NotARealPath");
    try
    {
        WebResponse GelenCevap06 = SiteyeBaglantiTalebi06.GetResponse();
        // do things with the result
    }
    catch (WebException ex)
    {
        HttpWebResponse asHttp = (HttpWebResponse)GelenCevap06;
        if (asHttp.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            // your 404 logic here
        }
        else 
        {
            // your "something went wrong but it's not a 404" logic 
        }
    }

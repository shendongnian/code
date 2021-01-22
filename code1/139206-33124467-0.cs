    var request = (HttpWebRequest)WebRequest.Create("http://www.your_third_parties_page.com");
    request.Timeout = 1000; //Timeout after 1000 ms
    
    try
    {
             using (var stream = request.GetResponse().GetResponseStream())
             using (var reader = new StreamReader(stream))
             {
                   Console.WriteLine(reader.ReadToEnd());
             }
    }
    catch (WebException ex)
    {
             if (ex.Status == WebExceptionStatus.Timeout)
             {
                   //If timeout then send SignalR message to inform the clients...
                   var context = GlobalHost.ConnectionManager.GetHubContext<YourHub>();
                   context.Clients.All.addNewMessageToPage("This behavious have been processing too long!");
             }
    }

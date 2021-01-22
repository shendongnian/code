        SyndicationFeed tracFeed;
        string user = "enr";
        string password = "enr";
        System.Net.WebClient wc = new System.Net.WebClient();
        wc.Credentials = new System.Net.NetworkCredential(user, password);
        //this works!
        string web = wc.DownloadString("http://trac:8080/project/login/xmlrpc");
        
        //this gives a 403 forbidden !! :-(
        System.IO.Stream webClientStream = wc.OpenRead("http://trac:8080/project/report/7?format=rss&USER=enr");
        try
        {
            using (XmlReader reader = XmlReader.Create(webClientStream))
            {
                tracFeed = SyndicationFeed.Load(reader);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            webClientStream.Close();
        }

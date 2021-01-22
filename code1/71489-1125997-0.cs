    Uri u = new Uri( @"http://launcher.worldofwarcraft.com/alert" );
    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(u);
    HttpWebResponse res = (HttpWebResponse)req.GetResponse();
    System.IO.Stream st = res.GetResponseStream();
    System.IO.StreamReader sr = new System.IO.StreamReader(st);
    string body = sr.ReadToEnd();
    System.Console.WriteLine( "{0}", body ); 

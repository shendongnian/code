    using System.Net;
    using System.IO;
...
        using (WebClient client = new WebClient()) {
            //... client.options
            Stream stream = client.OpenRead("http://.........");
            using (StreamReader reader = new StreamReader(stream)) {
                string content = reader.ReadToEnd();
            }
        }

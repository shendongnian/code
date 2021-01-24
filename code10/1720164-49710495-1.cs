            string source_location2 = "https://www.nseindia.com/ArchieveSearch";
            Uri uu2 = new Uri(source_location2);
            using (WebClient fileReader = new WebClient())
            {
                try
                {
                    var ua = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36";
                    fileReader.Headers.Add(HttpRequestHeader.UserAgent, ua);
                    fileReader.Headers["Accept"] = "/";
                    fileReader.QueryString.Add("h_filetype", "fobhav");
                    fileReader.QueryString.Add("date", "02-04-2018");
                    fileReader.QueryString.Add("section", "FO");
                    var response = fileReader.DownloadString(uu2);
                    //using Html Agility Pack to parse the response and get the download link. you need to add this package through nuget package manager to project for this code to work.
                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(response);
                    var fileLink = htmlDoc.DocumentNode.SelectSingleNode("//table//tr//td//a").Attributes["href"].Value;
                    //now sending the actual file request...
                    var fileReader2 = new WebClient();
                    fileReader2.Headers.Add(HttpRequestHeader.UserAgent, ua);
                    fileReader2.Headers["Accept"] = "/";
                    fileReader2.DownloadFile(new Uri("https://www.nseindia.com" + fileLink), @"d:\notworking.zip");
                    fileReader2.Dispose();
                }
                catch(Exception e)
                {
                    throw e;
                }
            }

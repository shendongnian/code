    var playlist = GetPlayList("https://www.youtube.com/playlist?list=PLTPg64KdGgYivEK9avhUlxsaJhD0TfpxW");
    Console.WriteLine(string.Join(playlist.Items.ToList()))
        public string MakeRequest(string link, string nextPage="")
        {
            string url = string.Format("https://api.youtubemultidownloader.com/playlist?url={0}&nextPageToken={1}", link, nextPage);
            HttpWebRequest wb = (HttpWebRequest)WebRequest.Create(url);
            wb.Method = "GET";
            wb.KeepAlive = true;
            wb.Proxy = null;
            wb.Referer = "https://youtubemultidownloader.com/playlist.html";
            wb.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:58.0) Gecko/20100101 Firefox/58.0";
            var value = new StreamReader(wb.GetResponse().GetResponseStream()).ReadToEnd();
            return value;
        }
        public PlayList GetPlayList(string link)
        {
            var json = MakeRequest(link);
            var playList = PlayList.FromJson(json);
            while (playList.Items.Count < playList.TotalResults)
            {
                json = MakeRequest(link, playList.NextPageToken);
                var newPagePlayList = PlayList.FromJson(json);
                playList.NextPageToken = newPagePlayList.NextPageToken;
                // playList.Items = playList.Items.Concat(newPagePlayList.Items).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                var index = 1;
                playList.Items = playList.Items.Concat(newPagePlayList.Items).ToDictionary((kvp) => (index++).ToString(), kvp => kvp.Value);
            }
            return playList;
        }

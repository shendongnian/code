    private void mediaElement1_MarkerReached(object sender, TimelineMarkerRoutedEventArgs e)
        {
            Dictionary<string, string> songAttribs = new Dictionary<string, string>();
            string playerFeed = HttpUtility.UrlDecode(e.Marker.Text);
            char[] delims = { '&' };
            string[] Attribs = playerFeed.Split(delims);
            foreach (String attrib in Attribs)
            {
                string[] keypair = attrib.Split('=');
                string key = "";
                string value = "";
                try
                {
                    key = keypair[0];
                }
                catch
                {
                    key = null;
                }
                if (key != null)
                {
                    try
                    {
                        value = keypair[1];
                    }
                    catch
                    {
                        value = "";
                    }
                    songAttribs.Add(keypair[0], keypair[1]);
                }
            }
            nowplaying.Title = songAttribs["title"];
            nowplaying.Artist = songAttribs["artist"];
            nowplaying.Duration = 0;
            this.label2.Content = "Artist: " + nowplaying.Artist;
            this.label3.Content = "Title: " + nowplaying.Title;
            this.label1.Content = playerFeed;
        }

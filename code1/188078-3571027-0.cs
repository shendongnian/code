    class YouTubeScraper
    {
        public HtmlNode FindObjectElement(string url)
        {
            HtmlNodeCollection scriptNodes = FindScriptNodes(url);
            for (int i = 0; i < scriptNodes.Count; ++i)
            {
                HtmlNode scriptNode = scriptNodes[i];
                string javascript = scriptNode.InnerHtml;
                int objectNodeLocation = javascript.IndexOf("<object");
                if (objectNodeLocation != -1)
                {
                    string htmlStart = javascript.Substring(objectNodeLocation);
                    int objectNodeEndLocation = htmlStart.IndexOf(">\" :");
                    if (objectNodeEndLocation != -1)
                    {
                        string finalEscapedHtml = htmlStart.Substring(0, objectNodeEndLocation + 1);
                        string unescaped = Unescape(finalEscapedHtml);
                        var objectDoc = new HtmlDocument();
                        objectDoc.LoadHtml(unescaped);
                        HtmlNode objectNode = objectDoc.GetElementbyId("movie_player");
                        return objectNode;
                    }
                }
            }
            return null;
        }
        public HtmlNode FindEmbedElement(string url)
        {
            HtmlNodeCollection scriptNodes = FindScriptNodes(url);
            for (int i = 0; i < scriptNodes.Count; ++i)
            {
                HtmlNode scriptNode = scriptNodes[i];
                string javascript = scriptNode.InnerHtml;
                int approxEmbedNodeLocation = javascript.IndexOf("<\\/object>\" : \"<embed");
                if (approxEmbedNodeLocation != -1)
                {
                    string htmlStart = javascript.Substring(approxEmbedNodeLocation + 15);
                    int embedNodeEndLocation = htmlStart.IndexOf(">\";");
                    if (embedNodeEndLocation != -1)
                    {
                        string finalEscapedHtml = htmlStart.Substring(0, embedNodeEndLocation + 1);
                        string unescaped = Unescape(finalEscapedHtml);
                        var embedDoc = new HtmlDocument();
                        embedDoc.LoadHtml(unescaped);
                        HtmlNode videoEmbedNode = embedDoc.GetElementbyId("movie_player");
                        return videoEmbedNode;
                    }
                }
            }
            return null;
        }
        protected HtmlNodeCollection FindScriptNodes(string url)
        {
            var doc = new HtmlDocument();
            WebRequest request = WebRequest.Create(url);
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                doc.Load(stream);
            }
            HtmlNode root = doc.DocumentNode;
            HtmlNodeCollection scriptNodes = root.SelectNodes("//script");
            return scriptNodes;
        }
        static string Unescape(string htmlFromJavascript)
        {
            // The JavaScript has escaped all of its HTML using backslashes. We need
            // to reverse this.
            // DISCLAIMER: I am a TOTAL Regex n00b; I make no claims as to the robustness
            // of this code. If you could improve it, please, I beg of you to do so. Personally,
            // I tested it on a grand total of three inputs. It worked for those, at least.
            return Regex.Replace(htmlFromJavascript, @"\\(.)", UnescapeFromBeginning);
        }
        static string UnescapeFromBeginning(Match match)
        {
            string text = match.ToString();
            if (text.StartsWith("\\"))
            {
                return text.Substring(1);
            }
            return text;
        }
    }

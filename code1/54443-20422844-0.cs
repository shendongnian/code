        public string HtmlAgi(string url, string key)
        {
           
            var Webget = new HtmlWeb();
            var doc = Webget.Load(url);
            HtmlNode ourNode = doc.DocumentNode.SelectSingleNode(string.Format("//meta[@name='{0}']", key));
            if (ourNode != null)
            {
             
                    return ourNode.GetAttributeValue("content", "");
               
            }
            else
            {
                return "not fount";
            }
        }

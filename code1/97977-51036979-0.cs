	public static class HttpHelper
    {
        public static string ReadHtmlContentFromUrl(string url)
        {
            string html = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            //Console.WriteLine(html);
            return html;
        }
        public static void GetAllFilePathAndSubDirectory(string baseUrl, List<PathInfo> pathInfos)
        {
            Uri baseUri = new Uri( baseUrl.TrimEnd('/') );
            string rootUrl = baseUri.GetLeftPart(UriPartial.Authority);
            Regex regexFile = new Regex("[0-9] <a href=\"(http:|https:)?(?<file>.*?)\"", RegexOptions.IgnoreCase);
            Regex regexDir = new Regex("dir.*?<a href=\"(http:|https:)?(?<dir>.*?)\"", RegexOptions.IgnoreCase);
            string html = ReadHtmlContentFromUrl(baseUrl);
            //Files
            MatchCollection matchesFile = regexFile.Matches(html);
            if (matchesFile.Count != 0)
                foreach (Match match in matchesFile)
                    if (match.Success)
                        pathInfos.Add(
                            new PathInfo( rootUrl + match.Groups["file"], false));
            //Dir
            MatchCollection matchesDir = regexDir.Matches(html);
            if (matchesDir.Count != 0)
                foreach (Match match in matchesDir)
                    if (match.Success)
                    {
                        var dirInfo = new PathInfo(rootUrl + match.Groups["dir"], true);
                        GetAllFilePathAndSubDirectory(dirInfo.AbsoluteUrlStr, dirInfo.Childs);
                        pathInfos.Add(dirInfo);
                    }                        
            
        }
        public static void PrintAllPathInfo(List<PathInfo> pathInfos)
        {
            pathInfos.ForEach(f =>
            {
                Console.WriteLine(f.AbsoluteUrlStr);
                PrintAllPathInfo(f.Childs);
            });
        }
	}
	public class PathInfo
    {
        public PathInfo(string absoluteUri, bool isDir)
        {
            AbsoluteUrl = new Uri(absoluteUri);
            IsDir = isDir;
            Childs = new List<PathInfo>();
        }
        public Uri AbsoluteUrl { get; set; }
        public string AbsoluteUrlStr
        {
            get { return AbsoluteUrl.ToString(); }
        }
        public string RootUrl
        {
            get { return AbsoluteUrl.GetLeftPart(UriPartial.Authority); }
        }
        public string RelativeUrl
        {
            get { return AbsoluteUrl.PathAndQuery; }
        }
        public string Query
        {
            get { return AbsoluteUrl.Query; }
        }
        public bool IsDir { get; set; }
        public List<PathInfo> Childs { get; set; }
        public override string ToString()
        {
            return String.Format("{0} IsDir {1} ChildCount {2} AbsUrl {3}", RelativeUrl, IsDir, Childs.Count, AbsoluteUrlStr);
        }
    }

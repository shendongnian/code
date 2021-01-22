    using System;
    using System.Net;
    using System.Web;
    using System.Web.Services;
    using System.Web.Script.Services;
    using System.Text.RegularExpressions;
    using HtmlAgilityPack;
    namespace GetMetaData
    {
    /// <summary>
    /// Summary description for MetaDataWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    [System.Web.Script.Services.ScriptService]
    public class MetaDataWebService : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(UseHttpGet = false)]
        public MetaData GetMetaData(string url)
        {
            MetaData objMetaData = new MetaData();
            //Get Title
            WebClient client = new WebClient();
            string sourceUrl = client.DownloadString(url);
            objMetaData.PageTitle = Regex.Match(sourceUrl, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
            //Method to get Meta Tags
            objMetaData.MetaDescription = GetMetaDescription(url);
            return objMetaData;
        }
        private string GetMetaDescription(string url)
        {
            string description = string.Empty;
            //Get Meta Tags
            var webGet = new HtmlWeb();
            var document = webGet.Load(url);
            var metaTags = document.DocumentNode.SelectNodes("//meta");
            if (metaTags != null)
            {
                foreach (var tag in metaTags)
                {
                    if (tag.Attributes["name"] != null && tag.Attributes["content"] != null && tag.Attributes["name"].Value.ToLower() == "description")
                    {
                        description = tag.Attributes["content"].Value;
                    }
                }
            }
            else
            {
                description = string.Empty;
            }
            return description;
        }
    }
    }

    using System;
    using System.Data;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.ServiceModel.Web;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GoogleSearchResults g1 = new GoogleSearchResults();
            const string json = @"{""responseData"": {""results"":[{""GsearchResultClass"":""GwebSearch"",""unescapedUrl"":""http://www.cheese.com/"",""url"":""http://www.cheese.com/"",""visibleUrl"":""www.cheese.com"",""cacheUrl"":""http://www.google.com/search?q\u003dcache:bkg1gwNt8u4J:www.cheese.com"",""title"":""\u003cb\u003eCHEESE\u003c/b\u003e.COM - All about \u003cb\u003echeese\u003c/b\u003e!."",""titleNoFormatting"":""CHEESE.COM - All about cheese!."",""content"":""\u003cb\u003eCheese\u003c/b\u003e - everything you want to know about it. Search \u003cb\u003echeese\u003c/b\u003e by name, by types   of milk, by textures and by countries.""},{""GsearchResultClass"":""GwebSearch"",""unescapedUrl"":""http://en.wikipedia.org/wiki/Cheese"",""url"":""http://en.wikipedia.org/wiki/Cheese"",""visibleUrl"":""en.wikipedia.org"",""cacheUrl"":""http://www.google.com/search?q\u003dcache:n9icdgMlCXIJ:en.wikipedia.org"",""title"":""\u003cb\u003eCheese\u003c/b\u003e - Wikipedia, the free encyclopedia"",""titleNoFormatting"":""Cheese - Wikipedia, the free encyclopedia"",""content"":""\u003cb\u003eCheese\u003c/b\u003e is a food consisting of proteins and fat from milk, usually the milk of   cows, buffalo, goats, or sheep. It is produced by coagulation of the milk \u003cb\u003e...\u003c/b\u003e""},{""GsearchResultClass"":""GwebSearch"",""unescapedUrl"":""http://www.ilovecheese.com/"",""url"":""http://www.ilovecheese.com/"",""visibleUrl"":""www.ilovecheese.com"",""cacheUrl"":""http://www.google.com/search?q\u003dcache:GBhRR8ytMhQJ:www.ilovecheese.com"",""title"":""I Love \u003cb\u003eCheese\u003c/b\u003e!, Homepage"",""titleNoFormatting"":""I Love Cheese!, Homepage"",""content"":""The American Dairy Association\u0026#39;s official site includes recipes and information   on nutrition and storage of \u003cb\u003echeese\u003c/b\u003e.""},{""GsearchResultClass"":""GwebSearch"",""unescapedUrl"":""http://www.gnome.org/projects/cheese/"",""url"":""http://www.gnome.org/projects/cheese/"",""visibleUrl"":""www.gnome.org"",""cacheUrl"":""http://www.google.com/search?q\u003dcache:jvfWnVcSFeQJ:www.gnome.org"",""title"":""\u003cb\u003eCheese\u003c/b\u003e"",""titleNoFormatting"":""Cheese"",""content"":""\u003cb\u003eCheese\u003c/b\u003e uses your webcam to take photos and videos, applies fancy special effects   and lets you share the fun with others. It was written as part of Google\u0026#39;s \u003cb\u003e...\u003c/b\u003e""}],""cursor"":{""pages"":[{""start"":""0"",""label"":1},{""start"":""4"",""label"":2},{""start"":""8"",""label"":3},{""start"":""12"",""label"":4},{""start"":""16"",""label"":5},{""start"":""20"",""label"":6},{""start"":""24"",""label"":7},{""start"":""28"",""label"":8}],""estimatedResultCount"":""14400000"",""currentPageIndex"":0,""moreResultsUrl"":""http://www.google.com/search?oe\u003dutf8\u0026ie\u003dutf8\u0026source\u003duds\u0026start\u003d0\u0026hl\u003den-GB\u0026q\u003dcheese""}}, ""responseDetails"": null, ""responseStatus"": 200}";
            g1 = JSONHelper.Deserialise<GoogleSearchResults>(json);
            foreach (Pages x in g1.responseData.cursor.pages)
            {
                // Anything you want to get
                Response.Write(x.label);
            }
        }
    }
    public class JSONHelper
    {
        public static T Deserialise<T>(string json)
        {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var serialiser = new DataContractJsonSerializer(typeof(T));
                return (T)serialiser.ReadObject(ms);
            }
        }
        public static string Serialize<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                return Encoding.Default.GetString(ms.ToArray());
            }
        }
    }
    [DataContract]
    public class GoogleSearchResults
    {
        [DataMember]
        public ResponseData responseData { get; set; }
        [DataMember]
        public string responseStatus { get; set; }
    
    }
    public class ResponseData
    {
        [DataMember]
        public Cursor cursor { get; set; }
        [DataMember]
        public IEnumerable<Results> results { get; set; }
    
    }
    [DataContract]
    public class Cursor
    {
        [DataMember]
        public IEnumerable<Pages> pages { get; set; }
    }
    [DataContract]
    public class Pages
    {
        [DataMember]
        public string start { get; set; }
        [DataMember]
        public string label { get; set; }
    }
    [DataContract]
    public class Results
    {
        [DataMember]
        public string unescapedUrl { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string visibleUrl { get; set; }
        [DataMember]
        public string cacheUrl { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string titleNoFormatting { get; set; }
        [DataMember]
        public string content { get; set; }
    }

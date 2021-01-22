    using System;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;
    
    namespace <YOUR_NAMESPACE>
    {
        public class JSONHelper
        {
            public static T Deserialise<T>(string json)
            {
                T obj = Activator.CreateInstance<T>();
                MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
                DataContractJsonSerializer serialiser = new DataContractJsonSerializer(obj.GetType());
                obj = (T)serialiser.ReadObject(ms);
                ms.Close();
                return obj;
            }
        }
    
        public class Result
        {
            public string GsearchResultClass { get; set; }
            public string unescapedUrl { get; set; }
            public string url { get; set; }
            public string visibleUrl { get; set; }
            public string cacheUrl { get; set; }
            public string title { get; set; }
            public string titleNoFormatting { get; set; }
            public string content { get; set; }
        }
    
        public class Page
        {
            public string start { get; set; }
            public int label { get; set; }
        }
    
        public class Cursor
        {
            public string resultCount { get; set; }
            public Page[] pages { get; set; }
            public string estimatedResultCount { get; set; }
            public int currentPageIndex { get; set; }
            public string moreResultsUrl { get; set; }
            public string searchResultTime { get; set; }
        }
    
        public class ResponseData
        {
            public Result[] results { get; set; }
            public Cursor cursor { get; set; }
        }
    
        public class GoogleSearchResults
        {
            public ResponseData responseData { get; set; }
            public object responseDetails { get; set; }
            public int responseStatus { get; set; }
        }
    }

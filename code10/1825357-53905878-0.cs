        public class mydictionary
        {
            public string a1 { get; set; }
            public string a2 { get; set; }
            public string a3 { get; set; }
        }
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Service/testdictionary",
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string testdictionary(mydictionary data)
        {
            if (data != null)
            {
                string str1 = data.a1.ToString();
                string str2 = data.a2.ToString();
                string str3 = data.a3.ToString();
                return "success".ToString();
            }
           else
            {
                return "unsuccess".ToString();
            }
           
        }

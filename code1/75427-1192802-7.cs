    using System;
    using System.Collections.Generic;
    using System.Text;
     
    using System.Web;
    using System.Net;
    using System.IO;
    using System.Runtime.Serialization.Json;
     
    namespace GoogleTranslationAPI
    {
     
       public class GoogleTranslator
       {
          private string _q = "";
          private string _v = "";
          private string _key = "";
          private string _langPair = "";
          private string _requestUrl = "";
          private string _translation = "";
     
          public GoogleTranslator(string queryTerm, VERSION version, LANGUAGE languageFrom,
             LANGUAGE languageTo, string key)
          {
             _q = HttpUtility.UrlPathEncode(queryTerm);
             _v = HttpUtility.UrlEncode(EnumStringUtil.GetStringValue(version));
             _langPair =
                HttpUtility.UrlEncode(EnumStringUtil.GetStringValue(languageFrom) +
                "|" + EnumStringUtil.GetStringValue(languageTo));
             _key = HttpUtility.UrlEncode(key);
     
             string encodedRequestUrlFragment =
                string.Format("?v={0}&q={1}&langpair={2}&key={3}",
                _v, _q, _langPair, _key);
     
             _requestUrl = EnumStringUtil.GetStringValue(BASEURL.TRANSLATE) + encodedRequestUrlFragment;
     
             GetTranslation();
          }
     
          public string Translation
          {
             get { return _translation; }
             private set { _translation = value; }
          }
     
          private void GetTranslation()
          {
             try
             {
                WebRequest request = WebRequest.Create(_requestUrl);
                WebResponse response = request.GetResponse();
     
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string json = reader.ReadLine();
                using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
                {
                   DataContractJsonSerializer ser =
                      new DataContractJsonSerializer(typeof(Translation));
                   Translation translation = ser.ReadObject(ms) as Translation;
     
                   _translation = translation.responseData.translatedText;
                }
             }
             catch (Exception) { }
          }
       }
    }

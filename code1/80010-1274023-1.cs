    using System.Net;
    using System.Collections.Specialized;
    
    ...
    using(WebClient client = new WebClient()) {
    
        NameValueCollection vals = new NameValueCollection();
        vals.Add("test", "test string");
        client.UploadValues("http://www.someurl.com/page.php", vals);
    }

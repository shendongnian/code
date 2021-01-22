    using System;
    using System.Net;
    class Program {
        static void Main () {
            HttpWebRequest req = WebRequest.Create(
                "http://www.oberon.ch/") as HttpWebRequest;
            HttpWebResponse rsp;
            try {
                rsp = req.GetResponse() as HttpWebResponse;
            } catch (WebException e) {
                if (e.Response is HttpWebResponse) {
                    rsp = e.Response as HttpWebResponse;
                } else {
                    rsp = null;
                }
            }
            if (rsp != null) {
                Console.WriteLine(rsp.StatusCode);
            }
        }
    }

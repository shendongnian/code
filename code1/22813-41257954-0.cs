    public class myweb : System.Net.WebClient
    {
        protected override System.Net.WebRequest GetWebRequest(System.Uri address)
        {
            System.Net.WebRequest request = (System.Net.WebRequest)base.GetWebRequest(address);
            //string host = "redmine.nonexistantdomain.com";
            //request.Headers.GetType().InvokeMember("ChangeInternal",
            //    System.Reflection.BindingFlags.NonPublic |
            //    System.Reflection.BindingFlags.Instance |
            //    System.Reflection.BindingFlags.InvokeMethod, null,
            //    request.Headers, new object[] { "Host", host }
            //);
            //server IP and port
            request.Proxy = new System.Net.WebProxy("http://28.14.88.71:80");
            // .NET 4.0 only
            System.Net.HttpWebRequest foo = (System.Net.HttpWebRequest)request;
            //foo.Host = host;
            // The below reflection-based operation is not necessary, 
            // if the server speaks HTTP 1.1 correctly
            // and the firewall doesn't interfere
            // https://yoursunny.com/t/2009/HttpWebRequest-IP/
            System.Reflection.FieldInfo horribleProxyServicePoint = (typeof(System.Net.ServicePoint))
                .GetField("m_ProxyServicePoint", System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance);
            horribleProxyServicePoint.SetValue(foo.ServicePoint, false);
            return foo; // or return request; if you don't neet this
        }
        }

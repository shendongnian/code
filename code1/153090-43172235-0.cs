       public class ExpectContinueAware : System.Net.WebClient
        {
            protected override System.Net.WebRequest GetWebRequest(Uri address)
            {
                System.Net.WebRequest request = base.GetWebRequest(address);
                if (request is System.Net.HttpWebRequest)
                {
                    var hwr = request as System.Net.HttpWebRequest;
                    hwr.ServicePoint.Expect100Continue = false;
                }
                return request;
            }
        }

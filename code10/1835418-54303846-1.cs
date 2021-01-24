    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    namespace SPORestConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                Uri uri = new Uri ("https://tenantname.sharepoint.com/sites/dev/");
                using (var client = new SPHttpClient(uri, "username@tanantname.onmicrosoft.com", "yourpassword"))
                {
                    var listTitle = "MyList8";
                    var itemId = 4;
                    var itemPayload = new { __metadata = new { type = "SP.Data.MyList8ListItem" }, Title = "updateviaRest" };
                    var endpointUrl = string.Format("{0}/_api/web/lists/getbytitle('{1}')/items({2})", uri, listTitle, itemId);
                    var headers = new Dictionary<string, string>();
                    headers["IF-MATCH"] = "*";
                    headers["X-HTTP-Method"] = "MERGE";
                    client.ExecuteJson(endpointUrl, HttpMethod.Post, headers, itemPayload);
                    Console.WriteLine("Task item has been updated");
                }
            }
        }
    }

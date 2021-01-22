     using System.Net.WebClient;
     using System.Collections.Specialized;
     class PostStuff
     {
       void DoPost(string address)
       {
          var client = new WebClient();
          var fields = new NameValueCollection();
          fields.Add("FirstName", "Anthony");
          fields.Add("LastName", "Jones");
          byte[] response = client.UploadValues(address, fields);
          //Do something with the response.
       }
     }

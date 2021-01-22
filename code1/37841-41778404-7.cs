string url = "page url";
HttpClient client = new HttpClient();
using (HttpResponseMessage response = client.GetAsync(url).Result)
{
   using (HttpContent content = response.Content)
   {
      string result = content.ReadAsStringAsync().Result;
   }
}
for more information about how to use the `HttpClient` class (especially in async cases), you can refer [this question][0]
[0]:https://stackoverflow.com/a/33031778/4390133

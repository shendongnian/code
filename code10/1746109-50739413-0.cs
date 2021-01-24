    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace CodeSearch
    {
        class Program
        {
            public static void Main()
            {
                Task t = CodeSearch();
                Task.WaitAll(new Task[] { t });
            }
            private static async Task CodeSearch()
            {
                try
                {
                    var username = "username";
                    var password = "Password/PAT";
    
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Add(
                            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                            Convert.ToBase64String(
                                System.Text.ASCIIEncoding.ASCII.GetBytes(
                                    string.Format("{0}:{1}", username, password))));
    
                        string url = "https://{instance}.almsearch.visualstudio.com/Git/_apis/search/codesearchresults?api-version=4.1-preview.1";
                        var content = new StringContent("{\"searchText\": \"OwinStartupAttribute\",  \"$top\": 10}", Encoding.UTF8, "application/json");
                        using (HttpResponseMessage response = client.PostAsync(url, content).Result)
                        {
                            response.EnsureSuccessStatusCode();
                            string responseBody = await response.Content.ReadAsStringAsync();
                            Console.WriteLine(responseBody);
                            
                        }
                        Console.ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                Console.ReadLine();
            }
        }
    }

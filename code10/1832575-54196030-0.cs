    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    
    namespace ConsoleApp20
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                string URL =
            "https://api.applicationinsights.io/v1/apps/{0}/{1}";
    
                string apikey = "xxxxx";
                string appid = "xxxx";
                string query = "query?query=customEvents| where timestamp >ago(30d)| top 5 by timestamp";
    
                string result = "";
    
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-api-key", apikey);
    
                var req = string.Format(URL, appid, query);
    
                HttpResponseMessage response = client.GetAsync(req).Result;
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    result = response.ReasonPhrase;
                }
    
                //get the schema of the results, like how many columns and each columns' name
                string schema = result.Remove(0, result.IndexOf("\"columns\":") + 1);
                schema = schema.Remove(schema.IndexOf("],")).Remove(0, schema.IndexOf("["));
                schema = schema + "]";
    
                //define a dictionary for storing structured results
                Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
    
                //convert schema string to json
                var json = JsonConvert.DeserializeObject<List<dynamic>>(schema);
    
                foreach (var item in json)
                {
                    var t1 = ((JObject)item).First;
                    var t2 = ((JObject)item).Last;
    
                    string s1 = t1.ToString();
    
                    List<string> list = new List<string>();
                    dict.Add(s1.Replace("\"name\":", "").Trim(), list);
                }
    
    
                //add the value to the dictionary
                //format the string
                string new_content = result.Remove(0, result.IndexOf("\"rows\":[")).Replace("\"rows\":[", "").Replace("]}]}", "");
    
                //add each row of value to an array
                var row_array = new_content.Split(']');
    
                foreach (var t in row_array)
                {
                    //if the row is empty, ignore it
                    if (t.Length == 0) continue;
    
                    int count = 0;
                    string a = "";
                    List<dynamic> json2 = null;
    
                    if (t.StartsWith(","))
                    {
                        a = t.Remove(0, 1) + "]";
                        json2 = JsonConvert.DeserializeObject<List<dynamic>>(a.Trim());
                    }
                    else if (!t.EndsWith("]"))
                    {
                        a = t + "]";
    
                        json2 = JsonConvert.DeserializeObject<List<dynamic>>(a.Trim());
                    }
    
                    foreach (var item in json2)
                    {
                        var s2 = ((JValue)item).ToString();
                        dict[dict.Keys.ElementAt(count)].Add(s2);
                        count++;
                    }
                }
    
                Console.WriteLine("---done---");
                Console.ReadLine();
            }
        }
    }

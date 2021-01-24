    using Microsoft.Graph;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
     
    namespace ConsoleApp4
    {
        class Program
        {
            static void Main(string[] args)
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                UserCreation uc = new UserCreation
                {
                    accountEnabled = true,
                    displayName = "cyril testgraphh",
                    mailNickName = "cyriltestgraphh",
                    passwordProfile = new PasswordProfile { ForceChangePasswordNextSignIn = false, Password = "Password!" },
                    userPrincipalName = "XXXXXX@jmaster.onmicrosoft.com"
                };
     
                string json = JsonConvert.SerializeObject(uc);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
     
                HttpResponseMessage response = httpClient.PostAsync("https://graph.microsoft.com/v1.0/users", content).Result;
                Console.Write(response);
                Console.ReadLine();
            }
        }
        class UserCreation
        {
            public bool accountEnabled { get; internal set; }
            public string displayName { get; internal set; }
            public string mailNickName { get; internal set; }
            public string userPrincipalName { get; internal set; }
            public PasswordProfile passwordProfile { get; internal set; }
        }
     
    }

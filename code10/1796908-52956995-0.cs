    using Microsoft.Rest;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApp2
    {
    class Program
    {
        static void Main(string[] args)
        {
            using (var apiClient = new MyAPIclient(null, HttpClientSingleton.Client))
            //I get Method not found 'Void Microsoft.Rest.ServiceClient`1..ctor(System.Net.Http.HttpClient, Boolean)'
            {
                var httpClient = apiClient.HttpClient;
            }
        }
        public class MyAPIclient : ServiceClient<MyAPIclient>
        {
            protected Uri _baseUri { get; set; }
            protected ServiceClientCredentials Credentials { get; set; }
            public MyAPIclient(ServiceClientCredentials credentials, HttpClient client) : base(client, disposeHttpClient: false)
            {
                this._baseUri = new Uri("https://stackoverflow.com");
                this.Credentials = credentials;
                if(credentials != null)
                    Credentials?.InitializeServiceClient(this);
            }
        }
        public static class HttpClientSingleton
        {
            public static readonly HttpClient Client = new HttpClient() { Timeout = TimeSpan.FromMinutes(30) };
        }
    }
    }

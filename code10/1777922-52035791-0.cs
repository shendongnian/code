    namespace BackgroundApplicationStarter
    {
        public sealed class StartupTask : IBackgroundTask
        {
            public void Run(IBackgroundTaskInstance taskInstance)
            {
                var deferral = taskInstance.GetDeferral();     
    
                StartApp();
            }
    
            private async void StartApp()
            {
                string fullPackageNameEncoded = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("BackgroundApplication1234-uwp_1.0.0.0_arm__a48w6404kk2ea"));
    
                Uri endpoint = new Uri("http://127.0.0.1:8080/api/iot/appx/app?appid=" + fullPackageNameEncoded);
    
                var client = new System.Net.Http.HttpClient();
                var byteArray = Encoding.ASCII.GetBytes("[insert your user name]:[insert your user password]");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("basic", Convert.ToBase64String(byteArray));
    
                HttpContent content = new StringContent("", Encoding.UTF8);
                System.Net.Http.HttpResponseMessage response = await client.PostAsync(endpoint, content);
                HttpContent responseContent = response.Content;
    
                Debug.WriteLine("Response StatusCode: " + (int)response.StatusCode);
            }
        }
    }

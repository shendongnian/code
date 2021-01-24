        void Handle_Clicked(object sender, System.EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUri);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password)));
            foreach (KeyValuePair<string, string> item in Answers)
            {
                Dictionary<string, string> collectAnswers = new Dictionary<string, string>()
                {
                     { item.Key, item.Value }
                };
            }
             var collectAnswersContent = new FormUrlEncodedContent(collectAnswers);
             var response = await client.PostAsync(api + "/addSurveyAnswers", collectAnswersContent);
             if (response.IsSuccessStatusCode)
             {
                 await DisplayAlert(null, "Thank you for answering the survey", "Close");
                 (sender as Button).BackgroundColor = Color.FromHex("#00afb9");
                            
             }
             else
             {
                 await DisplayAlert("Error", "Please Try Again, something went wrong", "OK");
                 (sender as Button).BackgroundColor = Color.FromHex("#00afb9");
             }
        }

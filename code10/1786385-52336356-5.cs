        HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUri);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password)));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/json"));
            var response = client.GetAsync(api).Result;
            if (response.IsSuccessStatusCode)
            {
                var getJson = client.GetStringAsync(api + resource).Result;
                var jsonString = JsonConvert.DeserializeObject<SurveyList>(getJson);
                surveyTitle.Text = jsonString.SurveyTtitle;
                Survey = new List<QuestionList>();
                    foreach (var surveys in jsonString.Questions)
                    {
                        Survey.Add(new QuestionList { QuestionText = surveys.QuestionText, QuestionCode = surveys.QuestionCode });
                    }
                    surveyList.ItemsSource = Survey;
                    surveyList.EndRefresh();
                    stackButton.IsVisible = true;
            }
            else
            {
                surveyTitle.Text = "No Surveys Available";
            }

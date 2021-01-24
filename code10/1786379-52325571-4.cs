    void Button_Clicked(object sender, System.EventArgs e)
    {
        using(var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://myip");
            var json = JsonConvert.SerializeObject(survey);
            
            var listViewDataContent = new FormUrlEncodedContent(json);
            var response = client.PostAsync("/api/GetData", listViewDataContent);
        }
    }

    string baseUrl = "http://localhost:5001/movies/"
    
    private async Task getMoviesAsync() {
        var accessToken = token; //assuming token is being retrieved and set somewhere else
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = 
            new AuthenticationHeaderValue("Bearer", accessToken);
        client.BaseAddress = new Uri(baseUrl);
        client.DefaultRequestHeaders.Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = await client.GetAsync("get");
        if (response.IsSuccessStatusCode) {
            MessageBox.Show( await response.Content.ReadAsStringAsync());
        } else {
            MessageBox.Show("Movies not Found");
        }
    }
    

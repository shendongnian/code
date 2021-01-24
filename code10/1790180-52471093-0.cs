    private static HttpClient client = new HttpClient();
    private const string webUrlTempplate = "http://localhost:59850/api/Donate_Table/{0}";
    private async void Delete(object sender, EventArgs e) {        
        var uri = new Uri(string.Format(webUrlTempplate, txtID.Text));        
        var result = await client.DeleteAsync(uri);
        if (result.IsSuccessStatusCode) {
            await DisplayAlert("Successfully", "your data have been Deleted", "OK");
        } else {
            //should have some action for failed requests.
        }
    }

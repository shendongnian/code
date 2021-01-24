    // Upload
    
    var RSClient = new RestClient(Properties.Settings.Default.GLPI_URL);
    
    var request = new RestRequest("Document", Method.POST);
    request.AddHeader("Session-Token", Properties.Settings.Default.GLPI_SESSION_TOKEN);
    request.AddHeader("App-Token", Properties.Settings.Default.GLPI_APP_TOKEN);
    request.AddHeader("Accept", "application/json");
    request.AddHeader("Content-Type", "multipart/form-data");
    request.AddQueryParameter("uploadManifest", "{\"input\": {\"name\": \"UploadFileTest\", \"_filename\": \"GiletsJaunes.jpg\"}}");
    request.AddFile("test", @"C:\path\to\File.jpg");
    
    IRestResponse response = RSClient.Execute(request);
    var content = response.Content;
    
    textBox2.Text = textBox2.Text + Environment.NewLine + content;

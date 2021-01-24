    private async Task SetUpTextBox(string s) {
        //This method is called in button event
        string textToSet = await GetTextAsync(s);
        read_Box.Text = textToSet;
    }
    private async Task<string> GetTextAsync(string s) {
        string textToReturn = "Hello";
        using (StreamReader sr = new StreamReader(File.OpenRead(s))) {
            textToReturn = await sr.ReadToEndAsync();
        }
        return textToReturn;
    }

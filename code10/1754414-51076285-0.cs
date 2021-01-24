    public static async Task<JObject> GetJsonAsync(Uri uri)
    {
       ... await client.GetStringAsync(uri).ConfigureAwait(false);
    
       else
       {
          // this will bomb
          someLabel.Text = "The parameter someValue is too big!";
       }
    }

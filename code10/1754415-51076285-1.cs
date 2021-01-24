    public static async Task<JObject> GetJsonAsync(Uri uri)
    {
       try{
         ...  // old context
         ... await client.GetStringAsync(uri).ConfigureAwait(false);
         ...  // new context
       }
       catch
       {
          // this might bomb
          someLabel.Text = "An Exception was raised!";
       }
    }

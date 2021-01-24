    if (response.IsSuccessStatusCode)
    {
         string json = await response.Content.ReadAsStringAsync();
    
         RootClass rootClass = JsonConvert.DeserializeObject<RootClass>(json);
    }

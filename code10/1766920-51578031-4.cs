    [JsonProperty("@new-code")]
    public string NewCode 
    {
        get
        {
            if (this.Option.Count == 0)
            {
                return string.Empty;
            }
            
            return this.Option.First().Value;
        }
    }

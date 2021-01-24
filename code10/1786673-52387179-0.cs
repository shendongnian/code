    public IList<SubscriberDefinition> GetAllSubscribers()
        {
            IList<SubscriberDefinition> allSubscribers = Caching.Get<IList<SubscriberDefinition>>(CacheKeys.ListAllSubscribers);
            if (allSubscribers != null && allSubscribers.Count > 0)
                return allSubscribers;
            try
            {
                SetBearerToken(HttpClient);
                HttpResponseMessage response = Task.Run(async () => await HttpClient.GetAsync("api/getallsubscribers")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var jsonstring = response.Content.ReadAsStringAsync();
                    jsonstring.Wait();
                    allSubscribers = JsonConvert.DeserializeObject<IList<SubscriberDefinition>>(jsonstring.Result);
                    Caching.Add(CacheKeys.ListAllSubscribers, allSubscribers, ECacheDuration.TwentyFourHours);
                    return allSubscribers;
                }
            }
            catch
            {
                return new List<SubscriberDefinition>();
            }
            return new List<SubscriberDefinition>();
        }

    private GasStationDatabase db;
        public GasStationQuery InitialAsyncGasStationsToDatabase()
        {
            string json;
            using (WebClient client = new WebClient())
            {
                json = client.DownloadString($"http://xxx/gasstations.json");
            }
            var gasStationList = JsonConvert.DeserializeObject<List<GasStation>>(json);
            
            foreach (GasStation gasStation in gasStationList )
            {
                db.SaveItemAsync(gasStation);
            }
            return;
        }

    public class Wrapper
    {
        public string Id { get; set; }
        public Item Item { get; set; }
        [JsonExtensionData]
        private IDictionary<string, JToken> _additionalData;
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            // Get the first key. If you have more than one, you may need
            // to customize this for your use case
            var id = _additionalData.Keys.FirstOrDefault();
            if (id != null)
            {
                // Assign to our Id property
                this.Id = id;
                // Create a reader for the subobject
                var itemReader = _additionalData[id].CreateReader();
                var serializer = new JsonSerializer();
                // Deserialize the subobject into our Item property
                this.Item = serializer.Deserialize<Item>(itemReader);
                itemReader.Close();
            }
        }
    }
    public class Item
    {
        public string Name { get; set; }
    }

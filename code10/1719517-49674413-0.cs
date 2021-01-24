    [JsonObject(MemberSerialization.OptIn)]
    public class LocationListResults
    {
        [JsonProperty("ok")]
        public Boolean OK { get; set; }
        [JsonProperty("establishments")]
        public List<Establishment> Establishments { get; set; }
    }
    public class Establishment
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("address")]
        public string  Address{ get; set; }
        [JsonProperty("lat")]
        public string Lat{ get; set; }
        [JsonProperty("lng")]
        public string Lng { get; set; }
    }
    var deserializedLocList = JsonConvert.DeserializeObject<LocationListResults>(await response.Content.ReadAsStringAsync());
    if (/* access here the boolean 'okay' from deserializedLocList or whatever you require */)
    {
        //I do get a true back, but here I want to create a foreach loop to get all the names
        await DisplayAlert("Succes", "HOORAY!", "OK");
    }
    else
    {
        await DisplayAlert("Fout", /* access here the value from deserializedLocList or whatever you need */, "OK");
    }

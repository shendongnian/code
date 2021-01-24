    public class ContactRoot
    {
        [JsonIgnore] // Do not serialize this
        public List<SimpleContact> SimpleContacts { get; set; }
        [JsonProperty(PropertyName = nameof(Contacts))]
        public List<ContactDto> SerializableContacts { get; set; }
    }

    public class ContactDto
    {
        /* List relevant properties here */
    }
    
    public class ContactRoot
    {
    	[JsonIgnore] // Do not serialize this
    	public List<Contact> Contacts { get; set; }
    	
    	[JsonProperty(Propertyname = nameof(Contacts)]
        public List<ContactDto> SerializableContacts { 
    		get => Contacts?.Select(x => /* data extraction */).ToList();
    		set => Contacts = value?.Select(x => /* data extraction */)?.ToList();
    	}
    }

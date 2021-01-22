	[DataContract]
	public class Item : IExtensibleDataObject
	{
		public virtual ExtensionDataObject ExtensionData { get; set; }
	
		[DataMember]
		public string ID { get; set; }
	
		[DataMember(Name = "Name", EmitDefaultValue = false)]
		private string _obsoleteName { get { return null; } set { if(value != null) FullName = value; } }
		
		[DataMember]
		public string FullName {get; set;}
	
		public Item()
			: this(String.Empty, String.Empty)
		{ }
	
		public Item(string id, string name)
		{
			ID = id ?? String.Empty;
			FullName = name ?? String.Empty;
		}
	}

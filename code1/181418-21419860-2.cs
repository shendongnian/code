	[DataContract]
	public class Item : IExtensibleDataObject
	{
		public virtual ExtensionDataObject ExtensionData { get; set; }
	
		[DataMember]
		public string ID { get; set; }
	
		[DataMember(Name = "Name", EmitDefaultValue = false)]
		private string _obsoleteName;
	
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
		
		[OnDeserialized]
		void OnDeserialized(StreamingContext context)
		{
			if(_obsoleteName != null && FullName == null)
			{
				//upgrade old serialized object to new version
				//by copying serialized Name field to newer FullName
				FullName = _obsoleteName;
                //set _obsoleteName to null so that it stops serializing
                _obsoleteName = null;
			}
		}
	}

		using System.Runtime.Serialization;
		[DataContract]
		public class DataObject
		{
		    [DataMember(Name = "user_id")]
		    public int UserId { get; set; }
		
		    [DataMember(Name = "detail_level")]
		    public string DetailLevel { get; set; }
		}

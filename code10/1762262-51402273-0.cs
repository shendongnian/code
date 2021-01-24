        public class Record
		{
			[Key]
			public int recordId{ get; set; }
			public string recordName{ get; set; }
			
			[ForeignKey("ParentRecordDetails")]
			public int ParentId {get;set;}
			public Record ParentRecordDetails {get;set;}
		
		}

		public class Certificate
		{
			[Key]
			public int Id { get; set; }
		
			public DateTime CreatedAt { get; set; }
		
			public DateTime RequestedAt { get; set; }
		
			[NotMapped]
			public Stream FileStream { get; set; }
		}

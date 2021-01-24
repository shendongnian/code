	public class Program
	{
		public static void Main()
		{
			
			List<Sku> skuList = new List<Sku>()  //Notice this is strongly typed as <Sku> now
			{
				"SKU001040AA",
				"SKU003010DED",
				"SKU002010VEVW",
				"SKU003040EEGE",
				"SKU001020GEF"
			};
	
			var results = skuList
				.Select( s => s.Group )
				.Distinct()
				.Select
				( 
					g => skuList.Where
					( 
						s => s.Group == g
					)
					.OrderBy
					(
						s => s.Priority
					)
					.First()
				);
																		  
			foreach (var r in results)
				Console.WriteLine(r);																	     
	
		}	
	}

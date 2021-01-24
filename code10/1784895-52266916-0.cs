    public class MyDocument 
    {
        public DateTime AgreementCancelDate { get; set; }
    }
    var client = new ElasticClient();
    
    client.Search<MyDocument>(s => s
        .Query(q => q
			.DateRange(dr => dr
				.Field(f => f.AgreementCancelDate)
				.GreaterThanOrEquals("now-30d/d")
			)
		)
    );

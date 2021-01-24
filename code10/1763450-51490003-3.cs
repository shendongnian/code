    [ElasticsearchType(Name = "Doc", IdProperty = nameof(Id))]
    public abstract class ESDocument
    {
    	public int Id { get; set; }
    	public JoinField MyJoinField { get; set; }
    }

    public JqGridData GetExtenderGridData([FromBody] Security security) { ... }
	public class Security
	{
		public object GridFilterParams { get; set; }
		public string SecurityCode { get; set; }
	}

    public JqGridData GetExtenderGridData([FromBody] Security security) { ... }
	public class Security
	{
		public string gridFilterParams {get; set; }
		public string securityCode {get; set; }
	}

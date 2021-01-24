	public class DataParser
	{	
		public DataParser(SmsService smsService)
		{
			SmsService _smsService = smsService;
		}
	
		public void ReceiveSms( )
		{
			//ParserLogic
			smsService.SaveMessage(...Values...);
		}
	}

    class MxRecordExtractor : IExtractor
    {
    	public string RecordType => "Mx";
    
    	public string ErrorMessage => DomainRegistrationCore.Models.DomainRecordType.MX;
    
    	public string GetValue(object record)
    	{
    		return ((Microsoft.Graph.DomainDnsMxRecord)record).MailExchange;
    	}
    }
    
    class VerificationRecordExtractor : IExtractor
    {
    	public string RecordType => "Txt";
    
    	public string ErrorMessage => DomainRegistrationCore.Models.DomainRecordType.TXT;
    
    	public string GetValue(object record)
    	{
    		return ((Microsoft.Graph.DomainDnsTxtRecord)record).Text;
    	}
    }

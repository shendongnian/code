    public abstract class Provider<T>
    {
    	protected HttpClient _Client;
    	protected SMSManagerAPIContext _Context;
    
    	public abstract DeliveryResponse SendSMS(T Sms);
    	protected abstract DeliveryResponse ParseResponse(HttpResponseMessage Response);
    	public abstract T PrepareMessage(SMS Sms);
    	protected abstract void SaveResponse(object Sms, HttpResponseMessage Response);
    }
    
    
    public class SMS {
    	public string Message { get; set; }
    }
    
    public class SMSManagerAPIContext{}
    
    
    public class DeliveryResponse { }
    
    
    public class PremiumSMS
    {
    	public double Cost { get; set; }
    	public string Message { get; set; }
    	
    }
    
    
    public class PremiumSmsProvider : Provider<PremiumSMS>
    {
    	public const double Cost = 3.99;
    	
    	public override PremiumSMS PrepareMessage(SMS Sms)
    	{
    		return new PremiumSMS {
    			Message = Sms.Message, 
    			Cost = Cost
    		};
    	}
    
    	public override DeliveryResponse SendSMS(PremiumSMS Sms)
    	{
    		throw new NotImplementedException();
    	}
    
    	protected override DeliveryResponse ParseResponse(HttpResponseMessage Response)
    	{
    		throw new NotImplementedException();
    	}
    
    	protected override void SaveResponse(object Sms, HttpResponseMessage Response)
    	{
    		throw new NotImplementedException();
    	}
    }

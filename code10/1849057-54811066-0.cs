    void Main()
    {
    	string data = "{\"VerifyOTPResult\":{\"ReturnCode\":\"200\",\"ReturnMsg\":\"Invalid OTP.\",\"Data\":{\"BrokerName\":null,\"ErrorMsg\":null,\"Id\":null,\"IsValidUser\":false,\"RoleName\":null}}}";
    	
    	var decRes = JsonConvert.DeserializeObject<VerifyOTPResultResponse>(data);
    	
    	Console.WriteLine(decRes.VerifyOTPResult.ReturnCode);
    	Console.WriteLine(decRes.VerifyOTPResult.ReturnMsg);
    
    	// Output:
    	// 200
    	// Invalid OTP.
    }
    
    public class VerifyOTPResultResponse
    {
    	public VerifyOTPResult VerifyOTPResult { get; set; }
    }
    
    public class VerifyOTPResult
    {
    	public string ReturnCode { get; set; }
    	public string ReturnMsg { get; set; }
    	public ValidateUserResult Data { get; set; }
    }
    
    public class ValidateUserResult
    {
    	public string Id { get; set; }
    	public bool IsValidUser { get; set; }
    	public string BrokerName { get; set; }
    
    	public string RoleName { get; set; }
    	public string ErrorMsg { get; set; }
    }

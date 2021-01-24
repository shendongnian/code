    public class AppointmentReasonResponse
    {
    	public string ErrorCode { get; set; }
    	public string ErrorMessage { get; set; }
    	public List<AppointmentReason> AppointmentReasonList { get; set; }
    }
    
    public class AppointmentReason
    {
    	public string ClassCode { get; set; }
    	public string ClassDescription { get; set; }
    	public bool Active { get; set; }
    	public bool IsPatientRelated { get; set; }
    	public List<ReasonCodeList> ReasonCodeList { get; set; }
    }
    
    public class ReasonCodeList:IEnumerable<ReasonCode>
    {
    	public List<ReasonCode> ReasonCodeLi { get; set; }
    
    	IEnumerator<ReasonCode> IEnumerable<ReasonCode>.GetEnumerator()
    	{
    		// Return the array object's IEnumerator.
    		foreach (ReasonCode Reason in ReasonCodeLi)
    		{
    			yield return Reason;
    		}
    	}
    
    	public IEnumerator<ReasonCode> GetEnumerator()
    	{
    		// Return the array object's IEnumerator.
    		return ReasonCodeLi.GetEnumerator();
    	}
    
    	IEnumerator IEnumerable.GetEnumerator()
    	{
    		// call the generic version of the method
    		return this.GetEnumerator();
    	}
    }
    
    public class ReasonCode
    {
    	public string Code { get; set; }
    	public string Description { get; set; }
    	public int Duration { get; set; }
    	public bool Active { get; set; }
    }

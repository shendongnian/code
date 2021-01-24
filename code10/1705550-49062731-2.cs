    public class Meet
    {
    	public int MeetId { get; set; }
    	public string MeetName { get; set; }
    	public DateTime MeetDate { get; set; }
    	public string MeetLocation { get; set; }
    	public string MeasurementType { get; set; }
    
    	public override bool Equals(object obj)
    	{
    		Meet input = obj as Meet;
    
    		if (obj==null)
    			return false;
    
    		return MeetId == input.MeetId &&
    			   MeetName == input.MeetName &&
    			   MeetDate == input.MeetDate &&
    			   MeetLocation == input.MeetLocation &&
    			   MeasurementType == input.MeasurementType;
    	}
    
    	public override int GetHashCode()
    	{
    		return base.GetHashCode();
    	}
    }

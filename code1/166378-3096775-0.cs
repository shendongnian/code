    public class ScheduleDataDetailsDC
    {
    	public ScheduleDataDetailsDC()
    	{
    		this.MinRateList = new List<ScheduleRateLineItem>();
    		//inialise other lists
    	}
    	
    	public List<ScheduleRateLineItem> MinRateList { get; private set; }
    	...
    }

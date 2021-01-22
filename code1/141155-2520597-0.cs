    public class Model
    {
    	public TimeSpan Time1 {get; set;}
    	public TimeSpan Time2 { get; set; }
    	public TimeSpan Time3 { get; set; }
    	public TimeSpan Time4 { get; set; }
    
    	public IEnumerable<TimeSpan> GetTimes()
    	{
    		yield return Time1;
    		yield return Time2;
    		yield return Time3;
    		yield return Time4;
    	}
    }

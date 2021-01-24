    void Main()
    {
    List<Appointment> appointments = new List<Appointment>();
    
                Appointment appointment1 = new Appointment();
                appointment1.StartDate = new DateTime(2018, 07, 11, 08, 00, 00);
                appointment1.FinishDate = new DateTime(2018, 07, 11, 11, 00, 00);
    
    	Appointment appointment2 = new Appointment();
    	appointment2.StartDate = new DateTime(2018, 07, 11, 10, 00, 00);
    	appointment2.FinishDate = new DateTime(2018, 07, 11, 12, 00, 00);
    
    	Appointment appointment3 = new Appointment();
    	appointment3.StartDate = new DateTime(2018, 07, 11, 09, 00, 00);
    	appointment3.FinishDate = new DateTime(2018, 07, 11, 12, 00, 00);
    
    	Appointment appointment4 = new Appointment();
    	appointment4.StartDate = new DateTime(2018, 07, 11, 14, 00, 00);
    	appointment4.FinishDate = new DateTime(2018, 07, 11, 16, 00, 00);
    
    	Appointment appointment5 = new Appointment();
    	appointment5.StartDate = new DateTime(2018, 07, 11, 15, 00, 00);
    	appointment5.FinishDate = new DateTime(2018, 07, 11, 17, 00, 00);
    
    	Appointment appointment6 = new Appointment();
    	appointment6.StartDate = new DateTime(2018, 07, 11, 18, 00, 00);
    	appointment6.FinishDate = new DateTime(2018, 07, 11, 19, 00, 00);
    
    	appointments.Add(appointment1);
    	appointments.Add(appointment2);
    	appointments.Add(appointment3);
    	appointments.Add(appointment4);
    	appointments.Add(appointment5);
    	appointments.Add(appointment6);
    
    	var ranges = appointments.Select(a => new Range {Start=a.StartDate, End=a.FinishDate});
    	var total = MergeTimes(ranges).Sum(a => (a.End-a.Start).TotalHours);
        Console.WriteLine(total);
    }
    
    public class Appointment
    {
    	public DateTime StartDate { get; set; }
    	public DateTime FinishDate { get; set; }
    
    }
    
    public class Range
    {
    	public DateTime Start {get;set;}
    	public DateTime End {get;set;}
    }
    
    public IEnumerable<Range> MergeTimes(IEnumerable<Range> times)
    {
    	if (times.Count() == 0)
    	{
    		return times;
    	}
    	Range[] orderedTimes = (from t in times
    							orderby t.Start
    							select t).ToArray();
    	List<Range> merged = new List<Range>();
    	Range current = new Range
    	{
    		Start = orderedTimes[0].Start,
    		End = orderedTimes[0].End
    	};
    	for (int i = 0; i < orderedTimes.Length; i++)
    	{
    		if (current.Start <= orderedTimes[i].End && current.End >= orderedTimes[i].Start)
    		{
    			current.Start = ((current.Start < orderedTimes[i].Start) ? current.Start : orderedTimes[i].Start);
    			current.End = ((current.End > orderedTimes[i].End) ? current.End : orderedTimes[i].End);
    		}
    		else
    		{
    			merged.Add(new Range
    			{
    				Start = current.Start,
    				End = current.End
    			});
    			current = new Range
    			{
    				Start = orderedTimes[i].Start,
    				End = orderedTimes[i].End
    			};
    		}
    	}
    	merged.Add(new Range
    	{
    		Start = current.Start,
    		End = current.End
    	});
    	return merged;
    }

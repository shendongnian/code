    class ShiftInfo : IEquatable<ShiftInfo>
    {
    	public ShiftInfo(TimeSpan startTime, string name)
    	{
    		this.StartTime = startTime;
    		this.Name = name;
    	}
    
    	public TimeSpan StartTime
    	{
    		get;
    		private set;
    	}
    
    	public string Name
    	{
    		get;
    		private set;
    	}
    
    	public bool Equals(ShiftInfo other)
    	{
    		return StartTime.Equals(other.StartTime);
    	}
    
    	public override bool Equals(object obj)
    	{
    		if (obj == null)
    		{
    			return false;
    		}
    
    		if (obj is ShiftInfo)
    		{
    			return this.Equals((ShiftInfo)obj);
    		}
    
    		return false;
    	}
    
    	public override int GetHashCode()
    	{
    		return StartTime.GetHashCode();
    	}
    }
    
    class ShiftConfig : IEnumerable<ShiftInfo>
    {
    	private readonly ICollection<ShiftInfo> _shiftInfos;
    	public ShiftConfig(params ShiftInfo[] shiftInfos)
    	{
    		_shiftInfos = shiftInfos.Distinct().OrderBy(e => e.StartTime).ToList();
    	}
    
    	public ShiftConfig(HashSet<ShiftInfo> shiftInfos)
    	{
    		_shiftInfos = shiftInfos.OrderBy(e => e.StartTime).ToList();
    	}
    
    	public IEnumerator<ShiftInfo> GetEnumerator()
    	{
    		return _shiftInfos.GetEnumerator();
    	}
    
    	IEnumerator IEnumerable.GetEnumerator()
    	{
    		return _shiftInfos.GetEnumerator();
    	}
    }
    
    class ShiftWorkItem
    {
    	public ShiftWorkItem(ShiftInfo shift, DateTime shiftFrom, DateTime shiftUntil, DateTime workFrom, DateTime workUntil)
    	{
    		Shift = shift;
    		ShiftFrom = shiftFrom;
    		ShiftUntil = shiftUntil;
    		WorkFrom = workFrom;
    		WorkUntil = workUntil;
    	}
    
    	public ShiftInfo Shift
    	{
    		get;
    		private set;
    	}
    
    	public DateTime ShiftFrom
    	{
    		get;
    		private set;
    	}
    
    	public DateTime ShiftUntil
    	{
    		get;
    		private set;
    	}
    
    	public TimeSpan ShiftDuration
    	{
    		get
    		{
    			return ShiftUntil - ShiftFrom;
    		}
    	}
    
    	public DateTime WorkFrom
    	{
    		get;
    		private set;
    	}
    
    	public DateTime WorkUntil
    	{
    		get;
    		private set;
    	}
    
    	public TimeSpan WorkDuration
    	{
    		get
    		{
    			return WorkUntil - WorkFrom;
    		}
    	}
    }
    
    static class ShiftConfigExtensions
    {
    	public static IEnumerable<ShiftWorkItem> EnumerateShifts(this ShiftConfig config, DateTime from, TimeSpan duration)
    	{
    		return EnumerateShifts(config, from, from.Add(duration));
    	}
    
    	public static IEnumerable<ShiftWorkItem> EnumerateShifts(this ShiftConfig config, DateTime from, DateTime until)
    	{
    		DateTime day = from.Date.AddDays(-1);
    		DateTime? shiftStart = null;
    		ShiftInfo lastShift = null;
    		while (true)
    		{
    			foreach (var shift in config)
    			{
    				var shiftEnd = day.Add(shift.StartTime);
    				if (shiftStart != null)
    				{
    					if ((shiftStart.Value <= from && shiftEnd >= from) || (shiftStart.Value <= until && shiftEnd >= until) || (shiftStart.Value > from && shiftEnd <= until))
    					{
    						var workFrom = shiftStart.Value < from ? from : shiftStart.Value;
    						var workUntil = shiftEnd > until ? until : shiftEnd;
    						yield return new ShiftWorkItem(lastShift, shiftStart.Value, shiftEnd, workFrom, workUntil);
    					}
    				}
    
    				if (shiftEnd >= until)
    				{
    					yield break;
    				}
    
    				shiftStart = shiftEnd;
    				lastShift = shift;
    			}
    
    			day = day.AddDays(1);
    		}
    	}
    }

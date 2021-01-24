    void Main()
    {
    	OrderedDictionaryByDateTime<double> data = new OrderedDictionaryByDateTime<double>();
    	data.Add(DateTime.Now, 1.1);
    	data.Add(DateTime.Now.AddDays(-1), 1.2);
    	data.Add(DateTime.Now.AddDays(2), 1.3);
    	data.Add(DateTime.Now.AddDays(3), 1.4);
    	data.Add(DateTime.Now.AddDays(-5), 1.5);
    	
    	var tomorrow = DateTime.Now.AddDays(1);
    	var oneHourBefore = DateTime.Now.AddHours(-1);
    	var theDayAfterTomorrow = DateTime.Now.AddDays(2);
    	var yesterday = DateTime.Now.AddDays(-1);
    	var fourDaysInThePast = DateTime.Now.AddDays(-4);
    	
    	data.GetValueClosestToTheDateTimeKey(tomorrow); // should be 1.1
    	data.GetValueClosestToTheDateTimeKey(oneHourBefore); // should be 1.1
    	data.GetValueClosestToTheDateTimeKey(yesterday); // should be 1.2
    	data.GetValueClosestToTheDateTimeKey(theDayAfterTomorrow); // should be 1.3
    	data.GetValueClosestToTheDateTimeKey(fourDaysInThePast); // should be 1.5
    }
    
    public class OrderedDictionaryByDateTime<TValue> : List<KeyValuePair<DateTime, TValue>>
    {
    	private readonly Dictionary<DateTime, int> _dictionary = new Dictionary<DateTime, int>();
    
    	public void Add(DateTime key, TValue value)
    	{
    		Add(new KeyValuePair<DateTime, TValue>(key, value));
    		_dictionary.Add(key, Count - 1);
    	}
    
    	public TValue Get(DateTime key)
    	{
    		var idx = _dictionary[key];
    		return this[idx].Value;
    	}
    
    	public TValue GetValueClosestToTheDateTimeKey(DateTime key)
    	{
    		var closestDate = _dictionary.Keys.OrderBy(t => Math.Abs((t - key).Ticks)).First();
    
    		return Get(closestDate);
    	}
    }

	var cron =  "* * */2 * ";
	var arr = cron.Split(new[]{" "},StringSplitOptions.RemoveEmptyEntries);
	var value = arr.Select((x,index)=>new {Value=x, Index=index}).First(x=>!x.Value.Equals("*"));
	var dictionaryOfActions = new Dictionary<Position,Action>
	{
		[Position.Minute] = ()=> ProcessMinute(),
		[Position.Hour] = ()=> ProcessHour(),
		[Position.Day] = ()=> ProcessDay(),
	};
	dictionaryOfActions[(Position)value.Index]();

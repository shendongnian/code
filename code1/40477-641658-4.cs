    static unsafe public void MeasureIntCasts()
	{
		int result;
		int intInput = 1234;
		object objInput = 1234;
		string strInput = "1234";
		timer1000.Measure("Copy", 10, delegate
		{
			result = intInput;
		});
		timer1000.Measure("Cast Object", 10, delegate
		{
			result = (int)objInput;
		});
		timer1000.Measure("int.Parse", 10, delegate
		{
			result = int.Parse(strInput);
		});
		timer1000.Measure("Convert.ToInt32", 10, delegate
		{
			result = Convert.ToInt32(strInput);
		});
	}

void Main()
{
	var conditionsChain = new SimpleCondition(0, 1);
		conditionsChain.AddNext(new SimpleCondition(1, 1))
		.AddNext(new SimpleCondition(2, 2))
		.AddNext(new SimpleCondition(4, 3))
		.AddNext(new SimpleCondition(6, 4))
		.AddNext(new SimpleCondition(9, 5))
		.AddNext(new SimpleCondition(12, 6))
		.AddNext(new SimpleCondition(15, 7))
		.AddNext(new SimpleCondition(18, 8))
		.AddNext(new SimpleCondition(24, 9))
		.AddNext(new SimpleCondition(30, 10))
		.AddNext(new SimpleCondition(36, 11))
		.AddNext(new SimpleCondition(48, 12))
		.AddNext(new SimpleCondition(60, 13))
		.AddNext(new SimpleCondition(14));
	for (int i = 0; i < 62; i++)
	{
		Console.WriteLine($"{i}: {conditionsChain.Evaluate(i) - VisitMonth(i)}");
	}
}
class SimpleCondition
{
	private SimpleCondition _next;
	
	private int _key;
	private int _result;
	
	public SimpleCondition(int key, int result)
	{
		_key = key;
		_result = result;
	}
	public SimpleCondition(int result) : this(-1, result)
	{
	}
	
	public int Evaluate(int key)
	{
		if(_key == -1)
		{
			return _result;	
		}
		
		if(key <= _key)
		{
			return _result;
		}
		else
		{
			if(_next == null)
			{
				throw new Exception("Default condition has not been configured.");
			}
			return _next.Evaluate(key);	
		}
	}
	public SimpleCondition AddNext(SimpleCondition next)
	{
		return _next = next;
	}
}

    private static void Producer()
    {
    	Console.WriteLine($"begin produce isCompleted:{_bc.IsCompleted}");
    	for (var i = 0; i < 5000; i++)
    		_bc.Add($"msg:{i}");
    	_bc.CompleteAdding();
    	Console.WriteLine($"end produce isCompleted:{_bc.IsCompleted}");
    }
    var batch = new List<string>();
    foreach (var s in _bc.GetConsumingEnumerable())
    {
    	batch.Add(s);
    	if (_bc.IsCompleted && _bc.Count == 0)
    	{
    	   break;
    	}
    }
    Console.WriteLine($"first:{batch.First()}, last:{batch.Last()}");
    Console.WriteLine($"consumed:{batch.Count}");

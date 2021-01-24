    bool keepGoing = true;
    for (var X = 0; X < test.Count && keepGoing; X++)
	{
		try
		{
			for (var i = 0; i <= 4 && keepGoing; i++)
			{
				if (GetElement(i).Text == test[X].Type.ToString())
				{
					switch (test[X].Type)
					{
						case Enum.Type.X:
							[Asserts]
							 break;
						case Enum.Type.Y:
							[Asserts]
							break;
						case Enum.Type.Z:                                                                                
						    [Asserts]
							break;
						default:
							break;
					}
					keepGoing = false;
				}
			}
		}
		catch (NoSuchElementException)
		{
			throw new NoSuchElementException($"text");
		}
	}

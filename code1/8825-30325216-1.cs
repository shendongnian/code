	var ar = new[]
	{
		new Node
		{
			Name = "1",
			Chilren = new[]
			{
				new Node
				{
					Name = "11",
					Children = new[]
					{
						new Node
						{
							Name = "111",
							
						}
					}
				}
			}
		}
	};
	
    var flattened = ar.RecursiveSelector(x => x.Children).ToList();

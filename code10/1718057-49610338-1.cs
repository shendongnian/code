    List<string> dodo = new List<string>()
    {
       d1.Text, d2.Text //...others
    };
    int sum = dodo
    		.Where(item => !String.IsNullOrEmpty(item))
    		.Sum(item =>
    		{
    			if (Int32.TryParse(item, out int parsedItem))
    			{
    				return parsedItem;
    			}
    			return 0;
    		});

	public static int FindLargest()
	{
		var files = Directory.GetFiles(@"C:\Dir");
		int largest = 0;
		Object lockObject = new object();
		Parallel.ForEach(files, file =>
		{
			foreach (var line in File.ReadLines(file))
			{
				int product = PerformAddition(Convert.ToInt32(line));
				if (product < 100)
				{
					continue;
				}
				if (product > largest)
				{
					lock(lockObject)
					{
						if (product >  largest)
						{
							largest = product;
						}
					}
				}
			}
		});
		return largest;
	}

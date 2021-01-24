	string[] collection = {"Zero", "One", "Two", "Three", "Four"};
	var random = new Random();
	var enumerableCollection = collection.OrderBy(e => random.NextDouble()).ToArray();
	Console.WriteLine(enumerableCollection.ElementAt(0));
	Console.WriteLine(enumerableCollection.ElementAt(0));
	Console.WriteLine(enumerableCollection.ElementAt(0));
	Console.WriteLine(enumerableCollection.ElementAt(0));
	Console.WriteLine(enumerableCollection.ElementAt(0));

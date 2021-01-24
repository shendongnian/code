		double d = 2;
		double? nd = d;
		int i = 2;
		int? ni = i;
		Console.WriteLine(d == d);
		Console.WriteLine(d == nd);
		Console.WriteLine(d == i);
		Console.WriteLine(d == ni);
		Console.WriteLine(nd == d);
		Console.WriteLine(nd == nd);
		Console.WriteLine(nd == i);
		Console.WriteLine(nd == ni);
		Console.WriteLine(i == d);
		Console.WriteLine(i == nd);
		Console.WriteLine(i == i);
		Console.WriteLine(i == ni);
		Console.WriteLine(ni == d);
		Console.WriteLine(ni == nd);
		Console.WriteLine(ni == i);
		Console.WriteLine(ni == ni);
		Console.WriteLine(d.Equals(d));
		Console.WriteLine(d.Equals(nd));
		Console.WriteLine(d.Equals(i));
		Console.WriteLine(d.Equals(ni)); // False
		Console.WriteLine(nd.Equals(d));
		Console.WriteLine(nd.Equals(nd));
		Console.WriteLine(nd.Equals(i)); // False
		Console.WriteLine(nd.Equals(ni)); // False
		Console.WriteLine(i.Equals(d)); // False
		Console.WriteLine(i.Equals(nd)); // False
		Console.WriteLine(i.Equals(i)); 
		Console.WriteLine(i.Equals(ni));
		Console.WriteLine(ni.Equals(d)); // False
		Console.WriteLine(ni.Equals(nd)); // False
		Console.WriteLine(ni.Equals(i)); 
		Console.WriteLine(ni.Equals(ni));

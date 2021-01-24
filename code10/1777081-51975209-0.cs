	public static void Main()
	{
		var d = new Dictionary<string,object>
		{
			{ "string"  , "Foo"        },
			{ "int"     , 123            },
			{ "MuComplexType", new MyComplexType { Text = "Bar" } }
		};
		
		var s = d.Values.OfType<string>().Single();
		var i = d.Values.OfType<int>().Single();
		var o = d.Values.OfType<MyComplexType>().Single();
		
		Console.WriteLine(s);
		Console.WriteLine(i);
		Console.WriteLine(o.Text);
	}

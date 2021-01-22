	void Main()
	{
		Console.Out.WriteLine(GetNameOfMethod(new Action(Main)));
		Console.Out.WriteLine(GetNameOfMethod(new Func<Delegate, string>(GetNameOfMethod)));
		Console.Out.WriteLine(GetNameOfMethod(new Func<int, short, long>(AddNumber)));
		Console.Out.WriteLine(GetNameOfMethod(new Action<int, short>(SwallowNumber)));
	}
	
	string GetNameOfMethod(Delegate d){
		return d.Method.Name;
	}
	
	long AddNumber(int x, short y){ return x+y; }
	void SwallowNumber(int x, short y){}

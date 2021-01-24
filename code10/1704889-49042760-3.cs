    class Factory
    {
         Dictionary<Func<string,bool>,Func<ICreate>> _map = new Dictionary<Func<string,bool>, Func<ICreate>>();
         public Factory()
         {
            _map.Add
            (
                a => a.Contains("classA"), 
                () => new a()
            );
            _map.Add
            (
                a => a.Contains("classB"), 
                () => new b()
            );
            _map.Add
            (
                a => a.Contains("classC"), 
                () => new c()
            );
         }
         public ICreate Create(string toMatch)
         {
			 var func = _map.Where( e => e.Key(toMatch) ).First().Value;
			 return func(); 
         }
    }
    public class Program
	{
		static public void Main()
		{
			var f = new Factory();
			var o = f.Create("This is a pattern that contains classA");
			Console.WriteLine("You just created an instance of '{0}'.", o.GetType().Name);
		}
	}

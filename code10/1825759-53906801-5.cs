    public class Person : System.Dynamic.DynamicObject
    {
        public string _name;
        public Person(string name)
        {
            _name = name;
        }
        public void TellMyName()
        {
            Console.WriteLine(_name);
        }
		
		public override bool TryInvoke(
            System.Dynamic.InvokeBinder binder, object[] args, out object result)
    	{
			result = null;
			if (args.Length == 0)
			{
				TellMyName();
				return true;
			}
			return false;
		}
    }
    // ...
    dynamic p = new Person("John");
    p();

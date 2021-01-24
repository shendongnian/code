	void Main()
	{
		Console.WriteLine((School)'A');
	}
	public class School
	{
		//list of enums
		public static readonly List<School> Values = new List<School>();
	    //"enum" values
		public static readonly School DVB = new School("DVB",'D',1);
		public static readonly School AVD = new School("AVD",'A',2);
		public static readonly School ASB = new School("ASB",'B',3);
		//properties
		public string Name {get;private set;}
		public char Code {get;private set;}
		public int Index {get;private set;}
		//constructor
		private School (string name, char code, int index)
		{
			if (Values.Exists(x => x.Name.Equals(name)) || Values.Exists(x => x.Code.Equals(code)) || Values.Exists(x => x.Index.Equals(index)))
			{
				throw new ArgumentException(string.Format("The Name, Code, and Index of each School value must be unique.  \nName: '{0}'\nSchool: '{1}'\nIndex: {2}", name, code, index));
			}
			Name = name;
			Code = code;
			Index = index;
			Values.Add(this);
		}
		//implicit conversion
		public static implicit operator School(string schoolName)
		{
			return Values.First(x => x.Name.Equals(schoolName));
		}
		public static implicit operator School(char schoolCode)
		{
			return Values.First(x => x.Code.Equals(schoolCode));
		}
		public static implicit operator School(int index)
		{
			return Values.First(x => x.Index.Equals(index));
		}
		//how should it be displayed?
		public override string ToString()
		{
			return Name;
		}
		//whatever other logic you need
	}

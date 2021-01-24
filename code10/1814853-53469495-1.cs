	class Class1
	{
		public Class1(string Name)
		{
			lstC = new List<Class1>();
			this.name = Name;
		}
		public List<Class1> lstC { get; set; }
		public string name { get; }
		public int member { get; set; }
	}
	class Program
	{
		static void Main(string[] args)
		{
			Class1 par = new Class1("A") { member = 4 };
			Class1 c1 = new Class1("A1") { member = 54};
			Class1 c2 = new Class1("A2") { member = 5 };
			par.lstC.Add(c1);
			par.lstC.Add(c2);
			Class1 c11 = new Class1("A11") { member = 39 };
			c1.lstC.Add(c11);
			Class1 c21 = new Class1("A21") { member = 67 };
			c2.lstC.Add(c21);
			List<int> result = new List<int>();
			GetMembers(par, ref result);
		}
		static void GetMembers(Class1 parent, ref List<int> lstMember)
		{
			lstMember.Add(parent.member);
			foreach (var child in parent.lstC)
			{
				GetMembers(child, ref lstMember);
			}		
		}
	}

    using System;
	using System.Collections.Generic;
							
	public class Program
	{
		public static void Main()
		{
			var p = new MyPerson();
			p.Name = "test";
			p.AddPhonenumber("555-2356");
			Console.WriteLine(string.Join(", ", p.Phonenumber));
			
			var c = new MyContact();
			c.Name = "contact";
			c.AddPhonenumber("222-235");
			Console.WriteLine(string.Join(", ", c.Phonenumber));
		}
	}
	
	
	public class Contact
	{
		public Contact() {
			this.Phonenumber = new List<string>();
		}
		public string Name { get; set; }
		public List<string> Phonenumber { get; set; }
		public string Foo { get; set; }
	}
	public class Person
	{
		public Person() {
			this.Phonenumber = new List<string>();
		}
		public string Name { get; set; }
		public List<string> Phonenumber { get; set; }
		public string Bar { get; set; }
	}
	
	public class MyContact: Contact, IType {
	}
	
	public class MyPerson: Person, IType {
	}
	
	
	public static class Extensions {
		public static void AddPhonenumber(this IType type, string number){
			type.Phonenumber.Add(number);
		}
	}
	
	public interface IType {
		string Name {get; set; }
		List<string> Phonenumber {get; set;}
	}

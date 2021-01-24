	using System;
	
	public class Student
	{
		public Student(string name, DateTime dateOfBirth)
		{
			Name = name;
			DateOfBirth = dateOfBirth;
		}
		
		public string Name { get; private set; }
		public DateTime DateOfBirth { get; private set; }
	}
	
	public static class Helpers
	{
		public static bool IsOlderThen(this DateTime date, TimeSpan age)
		{
			var now = DateTime.UtcNow;
			
			return now - date > age;
		}
	}	
	
	public class Program
	{
		public static void Main()
		{
			var adult = TimeSpan.FromDays(365 * 18);
			var studentOld = new Student("Alice", DateTime.Parse("1998/04/17"));
			var studentYoung = new Student("Bob", DateTime.Parse("2015/04/17"));
			
			Console.WriteLine("isAdult: " + studentOld.DateOfBirth.IsOlderThen(adult));
			Console.WriteLine("isAdult: " + studentYoung.DateOfBirth.IsOlderThen(adult));
		}
	}

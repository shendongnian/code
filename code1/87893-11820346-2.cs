		public class Characteristics
		{
			public enum Gender
			{
				Male,
				Female
			}
		}
		public class Person
		{
			public Characteristics.Gender Gender { get; set; }  
		}

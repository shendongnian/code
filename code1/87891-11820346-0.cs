		public class Person
		{
			public enum Gender
			{
				Male,
				Female
			}
			//Won't compile: auto-property has same name as enum
			public Gender Gender { get; set; }  
		}

		static void Main(string[] args)
		{
			Person steve = new Person()
			{
				IsHungry = true,
				IsLazy = false,
				IsSleepy = true
			};
			Dog bella= new Dog()
			{
				IsHungry = true,
				IsLazy = false,
				IsSleepy = true
			};
			bool match = DoAllBoolPropertiesMatch(steve, bella);
			Console.WriteLine($"\r\n----> Do Bools in Objects Match?: {match}");
		}
		private static bool DoAllBoolPropertiesMatch(object obj1, object obj2)
		{
			// For each Boolean property of object 1, check object 2:
			foreach(PropertyInfo propInfo in obj1.GetType().GetProperties())
			{
				// Property is boolean.
				if(propInfo.PropertyType == typeof(Boolean))
				{
					// Look for a property on obj2 with the same name that also returns a bool.
					PropertyInfo matchingPropInfo = obj2.GetType().GetProperty(propInfo.Name, typeof(Boolean));
					if(matchingPropInfo != null)
					{
						Console.WriteLine($"Evaluating Property {propInfo.Name} from obj1:");
						Console.WriteLine($"  - Value for Obj1 = [{propInfo.GetValue(obj1)}]");
						Console.WriteLine($"  - Value for Obj2 = [{matchingPropInfo.GetValue(obj2)}]");
						if(Convert.ToBoolean(propInfo.GetValue(obj1)) != Convert.ToBoolean(matchingPropInfo.GetValue(obj2)))
							return false;
					}
				}
			}
			return true;
		}
		public class Person
		{
			public bool IsHungry { get; set; }
			public bool IsSleepy { get; set; }
			public bool IsLazy { get; set; }
		}
		public class Dog
		{
			public bool IsHungry { get; set; }
			public bool IsSleepy { get; set; }
			public bool IsLazy { get; set; }
		}

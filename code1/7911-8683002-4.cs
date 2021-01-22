	public class MyDeepCopy
	{
		public static T DeepCopy<T>(T obj)
		{
			object result = null;
			using (var ms = new MemoryStream())
			{
				var formatter = new BinaryFormatter();
				formatter.Serialize(ms, obj);
				ms.Position = 0;
				result = (T)formatter.Deserialize(ms);
				ms.Close();
			}
			return (T)result;
		}
	}
	[Serializable] // Not required if using MemberwiseClone
	public class Person
	{
		public Person(int age, string description)
		{
			this.Age = age;
			this.Purchase.Description = description;
		}
		[Serializable] // Not required if using MemberwiseClone
		public class PurchaseType
		{
			public string Description;
			public PurchaseType ShallowCopy()
			{
				return (PurchaseType)this.MemberwiseClone();
			}
		}
		public PurchaseType Purchase = new PurchaseType();
		public int Age;
		// Add this if using nested MemberwiseClone.
		public Person ShallowCopy()
		{
			return (Person)this.MemberwiseClone();
		}
		// Add this if using nested MemberwiseClone.
		public Person DeepCopy()
		{
		        // Clone the root ...
			Person other = (Person) this.MemberwiseClone();
		        // ... then clone the nested class.
			other.Purchase = this.Purchase.ShallowCopy();
			return other;
		}
	}
	public struct PersonStruct
	{
		public PersonStruct(int age, string description)
		{
			this.Age = age;
			this.Purchase.Description = description;
		}
		public struct PurchaseType
		{
			public string Description;
		}
		public PurchaseType Purchase;
		public int Age;
		public PersonStruct ShallowCopy()
		{
			return (PersonStruct)this;
		}
		public PersonStruct DeepCopy()
		{
			return (PersonStruct)this;
		}
	}

	using System.Dynamic;
	using System.Runtime.CompilerServices;
	namespace ExtensionProperties
	{
		/// <summary>
		/// Dynamically associates properies to a random object instance
		/// </summary>
		/// <example>
		/// var jan = new Person("Jan");
		///
		/// jan.Age = 24; // regular property of the person object;
		/// jan.DynamicProperties().NumberOfDrinkingBuddies = 27; // not originally scoped to the person object;
		///
		/// if (jan.Age &lt; jan.DynamicProperties().NumberOfDrinkingBuddies)
		/// Console.WriteLine("Jan drinks too much");
		/// </example>
		/// <remarks>
		/// If you get 'Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo.Create' you should reference Microsoft.CSharp
		/// </remarks>
		public static class ObjectExtensions
		{
			///<summary>Stores extended data for objects</summary>
			private static ConditionalWeakTable<object, object> extendedData = new ConditionalWeakTable<object, object>();
			/// <summary>
			/// Gets a dynamic collection of properties associated with an object instance,
			/// with a lifetime scoped to the lifetime of the object
			/// </summary>
			/// <param name="obj">The object the properties are associated with</param>
			/// <returns>A dynamic collection of properties associated with an object instance.</returns>
			public static dynamic DynamicProperties(this object obj) => extendedData.GetValue(obj, _ => new ExpandoObject());
		}
	}

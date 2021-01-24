	public class Example
	{
		/// <summary>
		/// Cannot modify this function.
		/// </summary>
		private void Save<T>(T data) where T : struct { }
	
		public void PlaceA(IToIntCompatible input)
		{
			typeof(Example)
				.GetMethod("Save")
				.MakeGenericMethod(input.GetType())
				.Invoke(this, new object[] { input });
		}
	
		public void PlaceB(IToIntCompatible input)
		{
			typeof(Example)
				.GetMethod("Save")
				.MakeGenericMethod(input.GetType())
				.Invoke(this, new object[] { input });
		}
	}

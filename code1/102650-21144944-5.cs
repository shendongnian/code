	public partial class MyRandomClass 
	{
		/// <summary>
		/// Create a new empty instance and <see cref="PropertySpecifiedExtensions.Autospecify"/> it's properties when changed
		/// </summary>
		/// <returns></returns>
		public static MyRandomClass Create()
		{
			return PropertySpecifiedExtensions.Create<MyRandomClass>();
		}
	}

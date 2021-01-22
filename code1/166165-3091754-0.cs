    interface ISomeInterface
	{
		/// <summary>Handles this and that.</summary>
		void SomeMethod();
		/// <summary><see cref="ISomeInterface.SomeMethod()"/></summary>
		/// <param name="i">Param blabla.</param>
		void SomeMethod(int i);
	}
	class SomeClass : ISomeInterface
	{
		/// <summary><see cref="ISomeInterface.SomeMethod()"/></summary>
		public void SomeMethod() { }
		/// <summary><see cref="ISomeInterface.SomeMethod(int)"/></summary>
		public void SomeMethod(int i) { }
	}

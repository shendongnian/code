    /// <summary>
	/// Implementation of <see cref="IFoo"/>.
	/// </summary>
	public class Foo : IFoo
	{
		/// <summary>
		/// See <see cref="IFoo"/>.
		/// </summary>
		public void Foo() { ... }
		/// <summary>
		/// See <see cref="IFoo.Bar"/>
		/// </summary>
		public void Bar() { ... }
		/// <summary>
		/// This implementation of <see cref="IFoo.Snafu"/> uses the a caching algorithm for performance optimization.
		/// </summary>
		public void Snafu() { ... }
	}

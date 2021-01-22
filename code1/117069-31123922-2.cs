	/// <summary>
	/// Representation of an unreachable type, exposing a method to represent unreachable code.
	/// </summary>
	public static class Unreachable {
		/// <summary>
		/// Representation of unreachable code with return semantics.
		/// </summary>
		public static dynamic Code() {
			throw new NotImplementedException(@"Unreachable code was reached.");
		}
	}

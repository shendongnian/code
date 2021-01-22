		/// <summary>
		/// Create a list of the given anonymous class. <paramref name="definition"/> isn't called, it is only used
		/// for the needed type inference. This overload is for when you don't have an instance of the anon class
		/// and don't want to make one to make the list.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="definition"></param>
		/// <returns></returns>
	#pragma warning disable RECS0154 // Parameter is never used
		public static List<T> CreateListOfAnonType<T>(Func<T> definition)
	#pragma warning restore RECS0154 // Parameter is never used
		{
			return new List<T>();
		}
		/// <summary>
		/// Create a list of the given anonymous class. <paramref name="definition"/> isn't added to the list, it is
		/// only used for the needed type inference. This overload is for when you do have an instance of the anon
		/// class and don't want the compiler to waste time making a temp class to define the type.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="definition"></param>
		/// <returns></returns>
	#pragma warning disable RECS0154 // Parameter is never used
		public static List<T> CreateListOfAnonType<T>(T definition)
	#pragma warning restore RECS0154 // Parameter is never used
		{
			return new List<T>();
		}

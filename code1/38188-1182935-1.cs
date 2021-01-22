    /// <summary>
		/// Gets the given querystring parameter as a the specified value <see cref="Type"/>
		/// </summary>
		/// <typeparam name="T">The type to convert the querystring value to</typeparam>
		/// <param name="name">Querystring parameter name</param>
		/// <param name="defaultValue">Default value to return if parameter not found</param>
		/// <returns>The value as the specified <see cref="Type"/>, or the default value if not found</returns>
		public static T GetValueFromQueryString<T>(string name, T defaultValue) where T : struct
		{
			if (String.IsNullOrEmpty(name) || HttpContext.Current == null || HttpContext.Current.Request == null)
				return defaultValue;
			try
			{
				return (T)Convert.ChangeType(HttpContext.Current.Request.QueryString[name], typeof(T));
			}
			catch
			{
				return defaultValue;
			}
		}
		/// <summary>
		/// Gets the given querystring parameter as a the specified value <see cref="Type"/>
		/// </summary>
		/// <typeparam name="T">The type to convert the querystring value to</typeparam>
		/// <param name="name">Querystring parameter name</param>
		/// <returns>The value as the specified <see cref="Type"/>, or the types default value if not found</returns>
		public static T GetValueFromQueryString<T>(string name) where T : struct
		{
			return GetValueFromQueryString(name, default(T));
		}

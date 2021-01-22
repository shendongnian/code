		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="aText"></param>
		/// <returns></returns>
		public static Nullable<T> TryParse<T>(this string aText) where T : struct {
			T value;
			if (ParsingBinder<T>.TryParse(aText, out value)) {
				return value;
			}
			return null;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="aText"></param>
		/// <param name="aDefault"></param>
		/// <returns></returns>
		public static T TryParse<T>(this string aText, T aDefault) where T : struct {
			T value;
			if (!ParsingBinder<T>.TryParse(aText, out value)) {
				value = aDefault;
			}
			return value;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		static class ParsingBinder<T> where T : struct {
			/// <summary>
			/// 
			/// </summary>
			/// <typeparam name="T"></typeparam>
			/// <param name="aText"></param>
			/// <param name="aOutput"></param>
			/// <returns></returns>
			public delegate bool Delegate_TryParse<T>(string aText, out T aOutput) where T : struct;
			/// <summary>
			/// 
			/// </summary>
			static Delegate_TryParse<T> methodTryParse;
			/// <summary>
			/// 
			/// </summary>
			/// <returns></returns>
			public static Delegate_TryParse<T> TryParse {
				get {
					if (methodTryParse == null) {
						methodTryParse = GetParserMethod();
					}
					return methodTryParse;
				}
			}
			/// <summary>
			/// 
			/// </summary>
			/// <returns></returns>
			static Delegate_TryParse<T> GetParserMethod() {
				var typeT = typeof(T);
				var paramTypes = new Type[] { typeof(string), typeT.MakeByRefType() };
				var methodInfo = typeT.GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public, null, paramTypes, null);
				if (methodInfo == null) {
					var message = String.Format("Unable to retrieve a 'TryParse' method for type '{0}'.", typeT.Name);
					throw new Exception(message);
				}
				return (Delegate_TryParse<T>) Delegate.CreateDelegate(typeof(Delegate_TryParse<T>), methodInfo);
			}
		}

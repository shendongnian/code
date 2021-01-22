		/// <summary>
		/// Casts the body of the lambda expression to a <see cref="MethodCallExpression"/>.
		/// </summary>
		/// <exception cref="ArgumentException">If the body is not a method call.</exception>
		public static MethodCallExpression ToMethodCall(this LambdaExpression expression)
		{
			Guard.NotNull(() => expression, expression);
			var methodCall = expression.Body as MethodCallExpression;
			if (methodCall == null)
			{
				throw new ArgumentException(string.Format(
					CultureInfo.CurrentCulture,
					Resources.SetupNotMethod,
					expression.ToStringFixed()));
			}
			return methodCall;
		}

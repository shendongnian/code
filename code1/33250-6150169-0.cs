		/// <summary>
		/// <para>Lève l'évènement de changement de valeur sur l'objet <paramref name="sender"/>
		/// pour la propriété utilisée dans la lambda <paramref name="property"/>.</para>
		/// </summary>
		/// <param name="sender">L'objet portant la propriété et l'évènement.</param>
		/// <param name="property">Une expression lambda utilisant la propriété subissant la modification.</param>
		public static void NotifyPropertyChange(this INotifyPropertyChanged sender, Expression<Func<Object>> property)
		{
			if (sender == null)
				return;
			// Récupère le nom de la propriété utilisée dans la lambda en argument
			LambdaExpression lambda = property as LambdaExpression;
			MemberExpression memberExpression;
			if (lambda.Body is UnaryExpression)
			{
				UnaryExpression unaryExpression = lambda.Body as UnaryExpression;
				memberExpression = unaryExpression.Operand as MemberExpression;
			}
			else
			{
				memberExpression = lambda.Body as MemberExpression;
			}
			ConstantExpression constantExpression = memberExpression.Expression as ConstantExpression;
			PropertyInfo propertyInfo = memberExpression.Member as PropertyInfo;
			// Récupère l'event (car .Net interdit l'appel direct si on est pas dans la classe qui défini un event)
			MulticastDelegate eventDelegate = sender.GetType()
						.GetField(INotifyPropertyChangedEventFieldName, BindingFlags.Instance | BindingFlags.NonPublic)
						.GetValue(sender) as MulticastDelegate;
			foreach (Delegate handler in eventDelegate.GetInvocationList())
			{
				handler.Method.Invoke(handler.Target, new Object[] { sender, new PropertyChangedEventArgs(propertyInfo.Name) });
			}
		}

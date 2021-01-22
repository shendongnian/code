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
			// il faut remonter la hierarchie, car meme public, un event n est pas visible dans les enfants
			FieldInfo eventField;
			Type baseType = sender.GetType();
			do
			{
				eventField = baseType.GetField(INotifyPropertyChangedEventFieldName, BindingFlags.Instance | BindingFlags.NonPublic);
				baseType = baseType.BaseType;
			} while (eventField == null);
			// on a trouvé l'event, on peut invoquer tt les delegates liés
			MulticastDelegate eventDelegate = eventField.GetValue(sender) as MulticastDelegate;
			if (eventDelegate == null) return; // l'event n'est bindé à aucun delegate
			foreach (Delegate handler in eventDelegate.GetInvocationList())
			{
				handler.Method.Invoke(handler.Target, new Object[] { sender, new PropertyChangedEventArgs(propertyInfo.Name) });
			}
		}

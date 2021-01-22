    	private bool IsPropertyOrSubPropertyOf(Object Owner, Object LookFor)
		{
			if (Owner.Equals(LookFor))
			{
				// is it a property if they are the same?
				// may need a enum rather than bool
				return true;
			}
			PropertyInfo[] Properties = Owner.GetType().GetProperties();
			foreach (PropertyInfo pInfo in Properties)
			{
				var Value = pInfo.GetValue(Owner, null);
				if (typeof(IEnumerable).IsAssignableFrom(Value.GetType()))
				{
					// Becomes more complicated if it can be a collection of collections
					foreach (Object O in (IEnumerable)Value)
					{
						if (IsPropertyOrSubPropertyOf(O, LookFor))
							return true;
					}
				}
				else
				{
					if (IsPropertyOrSubPropertyOf(Value, LookFor))
					{
						return true;
					}
				}
			
			}
			return false;
		}

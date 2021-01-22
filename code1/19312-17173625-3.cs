	public static class TypeSwitch
	{
		public static void On<TV, T1>(TV value, Action<T1> action1)
			where T1 : TV
		{
			if (value is T1) action1((T1)value);
		}
		public static void On<TV, T1, T2>(TV value, Action<T1> action1, Action<T2> action2)
			where T1 : TV where T2 : TV
		{
			if (value is T1) action1((T1)value);
			else if (value is T2) action2((T2)value);
		}
		public static void On<TV, T1, T2, T3>(TV value, Action<T1> action1, Action<T2> action2, Action<T3> action3)
			where T1 : TV where T2 : TV where T3 : TV
		{
			if (value is T1) action1((T1)value);
			else if (value is T2) action2((T2)value);
			else if (value is T3) action3((T3)value);
		}
		// ... etc.
	}

	/// <summary>
	/// Helper Class that automates most of the actions required to implement INotifyPropertyChanged
	/// </summary>
	public static class HPropertyChanged
	{
		private static Dictionary<string, PropertyChangedEventArgs> argslookup = new Dictionary<string, PropertyChangedEventArgs>();
		public static string ThisPropertyName([CallerMemberName]string name = "")
		{
		    return name;
		}
		
		public static string GetPropertyName<T>(Expression<Func<T>> exp)
		{
			string rtn = "";
			MemberExpression mex = exp.Body as MemberExpression;
			if(mex!=null)
				rtn = mex.Member.Name;
			return rtn;
		}
		public static void SetValue<T>(ref T target, T newVal, object sender, PropertyChangedEventHandler handler, params string[] changed)
		{
			if (!target.Equals(newVal))
			{
				target = newVal;
				PropertyChanged(sender, handler, changed);
			}
		}
		public static void SetValue<T>(ref T target, T newVal, Action<PropertyChangedEventArgs> handler, params string[] changed)
		{
			if (!target.Equals(newVal))
			{
				target = newVal;
				foreach (var item in changed)
				{
					handler(GetArg(item));
				}
			}
		}
		
		public static void PropertyChanged(object sender,PropertyChangedEventHandler handler,params string[] changed)
		{
			if (handler!=null)
			{
				foreach (var prop in changed)
				{
					handler(sender, GetArg(prop));
				}
			}
		}
		public static PropertyChangedEventArgs GetArg(string name)
		{
			if (!argslookup.ContainsKey(name)) argslookup.Add(name, new PropertyChangedEventArgs(name));
			return argslookup[name];
		}
	}

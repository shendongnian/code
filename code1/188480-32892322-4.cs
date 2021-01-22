    public abstract class BaseViewModel : INotifyPropertyChanged
	{
		protected Dictionary<string, List<string>> DependencyMap;
		protected BaseViewModel()
		{
			DependencyMap = new Dictionary<string, List<string>>();
			foreach (var property in GetType().GetProperties())
			{
				var attributes = property.GetCustomAttributes<DependsOnPropertyAttribute>();
				foreach (var dependsAttr in attributes)
				{
					if (dependsAttr == null)
						continue;
					var dependence = dependsAttr.Dependence;
					if (!DependencyMap.ContainsKey(dependence))
						DependencyMap.Add(dependence, new List<string>());
					DependencyMap[dependence].Add(property.Name);
				}
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler == null)
				return;
			handler(this, new PropertyChangedEventArgs(propertyName));
			if (!DependencyMap.ContainsKey(propertyName))
                return;
			foreach (var dependentProperty in DependencyMap[propertyName])
			{
				handler(this, new PropertyChangedEventArgs(dependentProperty));
			}
		}
	}

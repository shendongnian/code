	public static class PropertySpecifiedExtensions2
	{
		/// <summary>
		/// Bind the <see cref="INotifyPropertyChanged.PropertyChanged"/> handler to automatically call each class's <see cref="IAutoNotifyPropertyChanged.Autonotify"/> method on the property name.
		/// </summary>
		/// <param name="entity">the entity to bind the autospecify event to</param>
		public static void Autonotify(this IAutoNotifyPropertyChanged entity)
		{
			entity.PropertyChanged += (me, e) => ((IAutoNotifyPropertyChanged)me).WhenPropertyChanges(e.PropertyName);
		}
		/// <summary>
		/// Create a new entity and <see cref="Autonotify"/> it's properties when changed
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T Create<T>() where T : IAutoNotifyPropertyChanged, new()
		{
			var ret = new T();
			ret.Autonotify();
			return ret;
		}
	}
	/// <summary>
	/// Used by <see cref="PropertySpecifiedExtensions.Autonotify"/> to standardize implementation behavior
	/// </summary>
	public interface IAutoNotifyPropertyChanged : INotifyPropertyChanged
	{
		void WhenPropertyChanges(string propertyName);
	}

	public static class PropertySpecifiedExtensions
	{
		private const string SPECIFIED_SUFFIX = "Specified";
		/// <summary>
		/// Bind the <see cref="INotifyPropertyChanged.PropertyChanged"/> handler to automatically set any xxxSpecified fields when a property is changed.  "Lazy" via reflection.
		/// </summary>
		/// <param name="entity">the entity to bind the autospecify event to</param>
		/// <param name="specifiedSuffix">optionally specify a suffix for the Specified property to set as true on changes</param>
		/// <param name="specifiedPrefix">optionally specify a prefix for the Specified property to set as true on changes</param>
		public static void Autospecify(this INotifyPropertyChanged entity, string specifiedSuffix = SPECIFIED_SUFFIX, string specifiedPrefix = null)
		{
			entity.PropertyChanged += (me, e) =>
			{
				foreach (var pi in me.GetType().GetProperties().Where(o => o.Name == specifiedPrefix + e.PropertyName + specifiedSuffix))
				{
					pi.SetValue(me, true, BindingFlags.SetField | BindingFlags.SetProperty, null, null, null);
				}
			};
		}
		/// <summary>
		/// Create a new entity and <see cref="Autospecify"/> its properties when changed
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="specifiedSuffix"></param>
		/// <param name="specifiedPrefix"></param>
		/// <returns></returns>
		public static T Create<T>(string specifiedSuffix = SPECIFIED_SUFFIX, string specifiedPrefix = null) where T : INotifyPropertyChanged, new()
		{
			var ret = new T();
			ret.Autospecify(specifiedSuffix, specifiedPrefix);
			return ret;
		}
	}

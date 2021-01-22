	public class MyModel : INotifyPropertyChanged
	{
		#region Bindable properties
		private DateTime? _When;
		public virtual DateTime? When
		{
			get { return _When; }
			set
			{
				SetField(ref _When, value);
				// When a change to `When` occurs, it means `ProxyWhenDate` and `ProxyWhenTime` have been changed as well,
				// so we need to raise a `PropertyChanged` notification for both of them.
				NotifyPropertyChanged(this.GetPropertyName((MyModel x) => x.ProxyWhenDate));
				NotifyPropertyChanged(this.GetPropertyName((MyModel x) => x.ProxyWhenTime));
			}
		}
		#endregion
		#region Proxies
		public virtual DateTime ProxyWhenDate
		{
			get
			{
				return When.HasValue ? When.Value : DateTime.UtcNow;
			}
			set
			{
				DateTime v = When.HasValue ? When.Value : DateTime.UtcNow;
				// Change only Year + Month + Day, keeping the rest as it is.
				When = new DateTime(value.Year, value.Month, value.Day, v.Hour, v.Minute, v.Second);
			}
		}
		public virtual DateTime ProxyWhenTime
		{
			get
			{
				return When.HasValue ? When.Value : DateTime.UtcNow;
			}
			set
			{
				DateTime v = When.HasValue ? When.Value : DateTime.UtcNow;
				// Change only Hour + Minute + Second, keeping the rest as it is.
				When = new DateTime(v.Year, v.Month, v.Day, value.Hour, value.Minute, value.Second);
			}
		}
		#endregion
		#region Object extensions
	    public static string GetPropertyName<TSource, TField>(this Object obj, Expression<Func<TSource, TField>> Field)
	    {
	        return (Field.Body as MemberExpression ?? ((UnaryExpression)Field.Body).Operand as MemberExpression).Member.Name;
	    }
		#endregion
		#region Support for bindings
	    public virtual event PropertyChangedEventHandler PropertyChanged;
	    // NotifyPropertyChanged will raise the PropertyChanged event passing the
	    // source property that is being updated.
	    public virtual void NotifyPropertyChanged(string propertyName)
	    {
	        if (PropertyChanged != null)
	        {
	            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
	        }
	    }
	    public virtual void NotifyPropertyChanged<TProperty>(Expression<Func<TProperty>> property)
	    {
	        var lambda = (LambdaExpression)property;
	        MemberExpression memberExpression;
	        if (lambda.Body is UnaryExpression)
	        {
	            var unaryExpression = (UnaryExpression)lambda.Body;
	            memberExpression = (MemberExpression)unaryExpression.Operand;
	        }
	        else
	        {
	            memberExpression = (MemberExpression)lambda.Body;
	        }
	        NotifyPropertyChanged(memberExpression.Member.Name);
	    }
	    public virtual bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
	    {
	        if (EqualityComparer<T>.Default.Equals(field, value))
	            return false;
	        field = value;
	        NotifyPropertyChanged(propertyName);
	        return true;
	    }
		#endregion
	}

    public class Wrapper : ICustomTypeDescriptor, INotifyPropertyChanged, IEditableObject, IChangeTracking
	{
		private bool _isChanged;
		public object DataSource { get; set; }
		public Wrapper(object dataSource)
		{
			if (dataSource == null)
				throw new ArgumentNullException("dataSource");
			DataSource = dataSource;
		}
		#region ICustomTypeDescriptor Members
		public AttributeCollection GetAttributes()
		{
			return new AttributeCollection(
					DataSource.GetType()
										.GetCustomAttributes(true)
										.OfType<Attribute>()
										.ToArray());
		}
		public string GetClassName()
		{
			return DataSource.GetType().Name;
		}
		public string GetComponentName()
		{
			return DataSource.ToString();
		}
		public TypeConverter GetConverter()
		{
			return new TypeConverter();
		}
		public EventDescriptor GetDefaultEvent()
		{
			return null;
		}
		public PropertyDescriptor GetDefaultProperty()
		{
			return null;
		}
		public object GetEditor(Type editorBaseType)
		{
			return Activator.CreateInstance(editorBaseType);
		}
		public EventDescriptorCollection GetEvents(Attribute[] attributes)
		{
			return TypeDescriptor.GetEvents(DataSource, attributes);
		}
		public EventDescriptorCollection GetEvents()
		{
			return TypeDescriptor.GetEvents(DataSource);
		}
		public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			return GetProperties();
		}
		private IEnumerable<PropertyDescriptor> _Properties;
		public IEnumerable<PropertyDescriptor> Properties
		{
			get
			{
				if (_Properties == null)
					_Properties = TypeDescriptor.GetProperties(DataSource)
					.Cast<PropertyDescriptor>()
					.Select(pd => new WrapperPropertyDescriptor(pd) as PropertyDescriptor)
					.ToList();
				return _Properties;
			}
		}
		public PropertyDescriptorCollection GetProperties()
		{
			return new PropertyDescriptorCollection(Properties.ToArray());
		}
		public object GetPropertyOwner(PropertyDescriptor pd)
		{
			return this;
		}
		#endregion ICustomTypeDescriptor
		#region ToString, Equals, GetHashCode
		public override string ToString()
		{
			return DataSource.ToString();
		}
		public override bool Equals(object obj)
		{
			var wrapper = obj as Wrapper;
			if (wrapper == null)
				return base.Equals(obj);
			else
				return DataSource.Equals(wrapper.DataSource);
		}
		public override int GetHashCode()
		{
			return DataSource.GetHashCode();
		}
		#endregion
		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged(string propertyName)
		{
			if (String.IsNullOrEmpty(propertyName))
				throw new ArgumentNullException("propertyName");
			_isChanged = true;
		
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion
		public IDictionary<string, object> MakeDump()
		{
			var result = new Dictionary<String, object>();
			foreach (var item in Properties)
				result[item.Name] = item.GetValue(this);
			return result;
		}
		#region IEditableObject Members
		private IDictionary<string, object> LastDump;
		public void BeginEdit()
		{
			LastDump = MakeDump();
		}
		public void CancelEdit()
		{
			if (LastDump != null)
			{
				foreach (var item in Properties)
					item.SetValue(this, LastDump[item.Name]);
				_isChanged = false;
			}
		}
		public void EndEdit()
		{
			AcceptChanges();
		}
		#endregion IEditableObject
		#region IChangeTracking
		public void AcceptChanges()
		{
			LastDump = null;
			_isChanged = false;
		}
		public bool IsChanged
		{
			get { return _isChanged;  }
		}
		#endregion IChangeTracking
	}
	public class WrapperPropertyDescriptor : PropertyDescriptor
	{
		private Wrapper _wrapper;
		private readonly PropertyDescriptor SourceDescriptor;
		public WrapperPropertyDescriptor(PropertyDescriptor sourceDescriptor) :
			base(sourceDescriptor)
		{
			if (sourceDescriptor == null)
				throw new ArgumentNullException("sourceDescriptor");
			SourceDescriptor = sourceDescriptor;
		}
		public override Type ComponentType
		{
			get
			{
				return SourceDescriptor.ComponentType;
			}
		}
		public override bool IsReadOnly
		{
			get
			{
				return SourceDescriptor.IsReadOnly;
			}
		}
		public override Type PropertyType
		{
			get
			{
				return SourceDescriptor.PropertyType;
			}
		}
		public override object GetValue(object component)
		{
			var wrapper = component as Wrapper;
			if (wrapper == null)
				throw new ArgumentException("Unexpected component", "component");
			var value = SourceDescriptor.GetValue(wrapper.DataSource);
			if (value == null)
				return value;
			var type = value.GetType();
			// If value is user class or structure it should 
			// be wrapped before return.
			if (type.Assembly != typeof(String).Assembly)
			{
				if (typeof(IEnumerable).IsAssignableFrom(type))
					throw new NotImplementedException("Here we should construct and return wrapper for collection");
				
				if (_wrapper == null) 
					_wrapper = new Wrapper(value);
				else 
					_wrapper.DataSource = value; 
				
				return _wrapper;
			}
			
			return value;
		}
		public override void SetValue(object component, object value)
		{
			var wrapper = component as Wrapper;
			if (wrapper == null)
				throw new ArgumentException("Unexpected component", "component");
			var actualValue = value;
			var valueWrapper = value as Wrapper;
			if (valueWrapper != null)
				actualValue = valueWrapper.DataSource;
			// Make dump of data source's previous values
			var dump = wrapper.MakeDump();
			SourceDescriptor.SetValue(wrapper.DataSource, actualValue);
			foreach (var item in wrapper.Properties)
			{
				var itemValue = item.GetValue(wrapper);
				if (!itemValue.Equals(dump[item.Name]))
					wrapper.OnPropertyChanged(item.Name);
			}
		}
		public override void ResetValue(object component)
		{
			var wrapper = component as Wrapper;
			if (wrapper == null)
				throw new ArgumentException("Unexpected component", "component");
			SourceDescriptor.ResetValue(wrapper.DataSource);
		}
		public override bool ShouldSerializeValue(object component)
		{
			var wrapper = component as Wrapper;
			if (wrapper == null)
				throw new ArgumentException("Unexpected component", "component");
			return SourceDescriptor.ShouldSerializeValue(wrapper.DataSource);
		}
		public override bool CanResetValue(object component)
		{
			var wrapper = component as Wrapper;
			if (wrapper == null)
				throw new ArgumentException("Unexpected component", "component");
			return SourceDescriptor.CanResetValue(wrapper.DataSource);
		}
	}

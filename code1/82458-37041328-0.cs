    public abstract class Bindable : MonoBehaviour, INotifyPropertyChanged
    {
        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();
        private static readonly StackTrace stackTrace = new StackTrace();
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        ///     Resolves a Property's name from a Lambda Expression passed in.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property"></param>
        /// <returns></returns>
        internal string GetPropertyName<T>(Expression<Func<T>> property)
        {
            var expression = (MemberExpression) property.Body;
            var propertyName = expression.Member.Name;
            Debug.AssertFormat(propertyName != null, "Bindable Property shouldn't be null!");
            return propertyName;
        }
        #region Notification Handlers
        /// <summary>
        ///     Notify's all other objects listening that a value has changed for nominated propertyName
        /// </summary>
        /// <param name="propertyName"></param>
        internal void NotifyOfPropertyChange(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        ///     Notifies subscribers of the property change.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="property">The property expression.</param>
        internal void NotifyOfPropertyChange<TProperty>(Expression<Func<TProperty>> property)
        {
            var propertyName = GetPropertyName(property);
            NotifyOfPropertyChange(propertyName);
        }
        /// <summary>
        ///     Raises the <see cref="PropertyChanged" /> event directly.
        /// </summary>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        internal void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion
        #region Getters
        /// <summary>
        ///     Gets the value of a property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        internal T Get<T>(Expression<Func<T>> property)
        {
            var propertyName = GetPropertyName(property);
            return Get<T>(GetPropertyName(property));
        }
        /// <summary>
        ///     Gets the value of a property automatically based on its caller.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal T Get<T>()
        {
            var name = stackTrace.GetFrame(1).GetMethod().Name.Substring(4); // strips the set_ from name;
            return Get<T>(name);
        }
        /// <summary>
        ///     Gets the name of a property based on a string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        internal T Get<T>(string name)
        {
            object value = null;
            if (_properties.TryGetValue(name, out value))
                return value == null ? default(T) : (T) value;
            return default(T);
        }
        #endregion
        #region Setters
        /// <summary>
        ///     Sets the value of a property whilst automatically looking up its caller name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        internal void Set<T>(T value)
        {
            var propertyName = stackTrace.GetFrame(1).GetMethod().Name.Substring(4); // strips the set_ from name;
            Set(value, propertyName);
        }
        /// <summary>
        ///     Sets the value of a property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="name"></param>
        internal void Set<T>(T value, string propertyName)
        {
            Debug.Assert(propertyName != null, "name != null");
            if (Equals(value, Get<T>(propertyName)))
                return;
            _properties[propertyName] = value;
            NotifyOfPropertyChange(propertyName);
        }
        /// <summary>
        ///     Sets the value of a property based off an Expression (()=>FieldName)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="property"></param>
        internal void Set<T>(T value, Expression<Func<T>> property)
        {
            var propertyName = GetPropertyName(property);
            Debug.Assert(propertyName != null, "name != null");
            if (Equals(value, Get<T>(propertyName)))
                return;
            _properties[propertyName] = value;
            NotifyOfPropertyChange(propertyName);
        }
        #endregion
    }

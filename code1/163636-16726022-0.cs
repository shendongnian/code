        /// <summary>
        /// creates a new trigger property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        protected virtual TriggerProperty<T> Create<T>(T value, Enum name)
        {
            var pt = new TriggerProperty<T>(value, OnPropertyChanged, Enum.GetName(name.GetType(), name));
            _properties[name.GetHashCode()] = pt;
            return pt;
        }

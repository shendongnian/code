        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        /// <devdoc>Do not serialize this delegate, since we do not want to have
        /// the event listener persisted.</devdoc>
        [NonSerialized]
        private PropertyChangedEventHandler _propertyChanged;
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        /// <remarks>Effectively, this is fired whenever the wrapped MapXtreme theme 
        /// of the AssociatedTheme property gets changed
        /// via the MapXtreme API.</remarks>
        /// <devdoc>The implementation using the public event and the private delegate is
        /// to avoid serializing the (probably non-serializable) listeners to this event.
        /// see http://www.sanity-free.org/113/csharp_binary_serialization_oddities.html
        /// for more information.
        /// </devdoc>
        public event PropertyChangedEventHandler PropertyChanged
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                _propertyChanged = (PropertyChangedEventHandler)Delegate.Combine(_propertyChanged, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                _propertyChanged = (PropertyChangedEventHandler)Delegate.Remove(_propertyChanged, value);
            }
        }

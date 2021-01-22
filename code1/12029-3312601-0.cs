using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Globalization;
namespace Infrastructure
{
    /// <summary>
    /// Adds a RaisePropertyChanged method to objects implementing INotifyPropertyChanged.
    /// </summary>
    public static class NotifyPropertyChangeExtension
    {
        #region private fields
        private static readonly Dictionary<string, PropertyChangedEventArgs> eventArgCache = new Dictionary<string, PropertyChangedEventArgs>();
        private static readonly object syncLock = new object();
        #endregion
        #region the Extension's
        /// <summary>
        /// Verifies the name of the property for the specified instance.
        /// </summary>
        /// <param name="bindableObject">The bindable object.</param>
        /// <param name="propertyName">Name of the property.</param>
        [Conditional("DEBUG")]
        public static void VerifyPropertyName(this INotifyPropertyChanged bindableObject, string propertyName)
        {
            bool propertyExists = TypeDescriptor.GetProperties(bindableObject).Find(propertyName, false) != null;
            if (!propertyExists)
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture,
                    "{0} is not a public property of {1}", propertyName, bindableObject.GetType().FullName));
        }
        /// <summary>
        /// Gets the property name from expression.
        /// </summary>
        /// <param name="notifyObject">The notify object.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>a string containing the name of the property.</returns>
        public static string GetPropertyNameFromExpression<T>(this INotifyPropertyChanged notifyObject, Expression<Func<T>> propertyExpression)
        {
            return GetPropertyNameFromExpression(propertyExpression);
        }
        /// <summary>
        /// Raises a property changed event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bindableObject">The bindable object.</param>
        /// <param name="propertyExpression">The property expression.</param>
        public static void RaisePropertyChanged<T>(this INotifyPropertyChanged bindableObject, Expression<Func<T>> propertyExpression)
        {
            RaisePropertyChanged(bindableObject, GetPropertyNameFromExpression(propertyExpression));
        }
        #endregion
        /// <summary>
        /// Raises the property changed on the specified bindable Object.
        /// </summary>
        /// <param name="bindableObject">The bindable object.</param>
        /// <param name="propertyName">Name of the property.</param>
        private static void RaisePropertyChanged(INotifyPropertyChanged bindableObject, string propertyName)
        {
            bindableObject.VerifyPropertyName(propertyName);
            RaiseInternalPropertyChangedEvent(bindableObject, GetPropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Raises the internal property changed event.
        /// </summary>
        /// <param name="bindableObject">The bindable object.</param>
        /// <param name="eventArgs">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void RaiseInternalPropertyChangedEvent(INotifyPropertyChanged bindableObject, PropertyChangedEventArgs eventArgs)
        {
            // get the internal eventDelegate
            var bindableObjectType = bindableObject.GetType();
            // search the base type, which contains the PropertyChanged event field.
            FieldInfo propChangedFieldInfo = null;
            while (bindableObjectType != null)
            {
                propChangedFieldInfo = bindableObjectType.GetField("PropertyChanged", BindingFlags.Instance | BindingFlags.NonPublic);
                if (propChangedFieldInfo != null)
                    break;
                bindableObjectType = bindableObjectType.BaseType;
            }
            if (propChangedFieldInfo == null)
                return;
            // get prop changed event field value
            var fieldValue = propChangedFieldInfo.GetValue(bindableObject);
            if (fieldValue == null)
                return;
            MulticastDelegate eventDelegate = fieldValue as MulticastDelegate;
            if (eventDelegate == null)
                return;
            // get invocation list
            Delegate[] delegates = eventDelegate.GetInvocationList();
            // invoke each delegate
            foreach (Delegate propertyChangedDelegate in delegates)
                propertyChangedDelegate.Method.Invoke(propertyChangedDelegate.Target, new object[] { bindableObject, eventArgs });
        }
        /// <summary>
        /// Gets the property name from an expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>The property name as string.</returns>
        private static string GetPropertyNameFromExpression<T>(Expression<Func<T>> propertyExpression)
        {
            var lambda = (LambdaExpression)propertyExpression;
            MemberExpression memberExpression;
            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression)lambda.Body;
                memberExpression = (MemberExpression)unaryExpression.Operand;
            }
            else memberExpression = (MemberExpression)lambda.Body;
            return memberExpression.Member.Name;
        }
        /// <summary>
        /// Returns an instance of PropertyChangedEventArgs for the specified property name.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property to create event args for.
        /// </param>		
        private static PropertyChangedEventArgs GetPropertyChangedEventArgs(string propertyName)
        {
            PropertyChangedEventArgs args;
            lock (NotifyPropertyChangeExtension.syncLock)
            {
                if (!eventArgCache.TryGetValue(propertyName, out args))
                    eventArgCache.Add(propertyName, args = new PropertyChangedEventArgs(propertyName));
            }
            return args;
        }
    }
}

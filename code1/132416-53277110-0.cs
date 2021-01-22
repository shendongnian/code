    using System;
    using System.Linq.Expressions;
    using System.Windows.Forms;
    
    namespace ControlExtention
    {
        public static class ControlExtentions
        {
            // https://stackoverflow.com/questions/661561/how-do-i-update-the-gui-from-another-thread
            // Usage: myLabel.SetPropertyThreadSafe(() => myLabel.Text, status); // status has to be a string or this will fail to compile
            private delegate void SetPropertyThreadSafeDelegate<TResult>(Control @this, Expression<Func<TResult>> property, TResult value);
    
            /// <summary>
            /// Set property from a Thread other than the UI Thread safely.
            /// Use with Lambda-Expression: ControlObject.SetPropertyThreadSafe(() => ControlObject.Property, NewPropertyValue);
            /// </summary>
            /// <typeparam name="TResult">Do not set.</typeparam>
            /// <param name="this">Use lambda expression.</param>
            /// <param name="property">Use lambda expression.</param>
            /// <param name="value">Use lambda expression.</param>
            public static void SetPropertyThreadSafe<TResult>(this Control @this, Expression<Func<TResult>> property, TResult value)
            {
                System.Reflection.PropertyInfo propertyInfo = (property.Body as MemberExpression).Member as System.Reflection.PropertyInfo;
    
                // check ob property überhaupt ein teil von this ist
                if (propertyInfo == null || !@this.GetType().IsSubclassOf(propertyInfo.ReflectedType) || @this.GetType().GetProperty(propertyInfo.Name, propertyInfo.PropertyType) == null)
                {
                    throw new ArgumentException("The lambda expression 'property' must reference a valid property on this Control.");
                }
    
                if (@this.InvokeRequired)
                {
                    @this.Invoke(new SetPropertyThreadSafeDelegate<TResult>(SetPropertyThreadSafe), new object[] { @this, property, value });
                }
                else
                {
                    @this.GetType().InvokeMember(propertyInfo.Name, System.Reflection.BindingFlags.SetProperty, null, @this, new object[] { value });
                }
            }
    
            private delegate TResult GetPropertyThreadSafeDelegate<TResult>(Control @this, Expression<Func<TResult>> property);
    
            /// <summary>
            /// Get property from a Thread other than the UI Thread safely.
            /// Use with Lambda-Expression: value = ControlObject.GetPropertyThreadSafe(() => ControlObject.Property);
            /// </summary>
            /// <typeparam name="TResult">Do not set.</typeparam>
            /// <param name="this">Use lambda expression.</param>
            /// <param name="property">Use lambda expression.</param>
            /// <param name="value">Use lambda expression.</param>
            public static TResult GetPropertyThreadSafe<TResult>(this Control @this, Expression<Func<TResult>> property)
            {
                System.Reflection.PropertyInfo propertyInfo = (property.Body as MemberExpression).Member as System.Reflection.PropertyInfo;
    
                // check ob property überhaupt ein teil von this ist
                if (propertyInfo == null || !@this.GetType().IsSubclassOf(propertyInfo.ReflectedType) || @this.GetType().GetProperty(propertyInfo.Name, propertyInfo.PropertyType) == null)
                {
                    throw new ArgumentException("The lambda expression 'property' must reference a valid property on this Control.");
                }
    
                if (@this.InvokeRequired)
                {
                    return (TResult)@this.Invoke(new GetPropertyThreadSafeDelegate<TResult>(GetPropertyThreadSafe), new object[] { @this, property });
                }
                else
                {
                    return (TResult)@this.GetType().InvokeMember(propertyInfo.Name, System.Reflection.BindingFlags.GetProperty, null, @this, new object[] { });
                }
            }
        }
    }

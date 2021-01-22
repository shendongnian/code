    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using Custom.Extensions;
    
    namespace Custom.DefaultValueAttributes
    {
        /// <summary>
        /// This class's DefaultValue attribute allows the programmer to use DateTime.Now as a default value for a property.
        /// Inspired from https://code.msdn.microsoft.com/A-flexible-Default-Value-11c2db19. 
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public sealed class DefaultDateTimeValueAttribute : DefaultValueAttribute
        {
            public string DefaultValue { get; set; }
            private object _value;
    
            public override object Value
            {
                get
                {
                    if (_value == null)
                        return _value = GetDefaultValue();
    
                    return _value;
                }
            }
    
            /// <summary>
            /// Initialized a new instance of this class using the desired DateTime value. A string is expected, because the value must be generated at runtime.
            /// Example of value to pass: Now. This will return the current date and time as a default value. 
            /// Programmer tip: Even if the parameter is passed to the base class, it is not used at all. The property Value is overridden.
            /// </summary>
            /// <param name="defaultValue">Default value to render from an instance of <see cref="DateTime"/></param>
            public DefaultDateTimeValueAttribute(string defaultValue) : base(defaultValue)
            {
                DefaultValue = defaultValue;
            }
    
            public static DateTime GetDefaultValue(Type objectType, string propertyName)
            {
                var property = objectType.GetProperty(propertyName);
                var attribute = property.GetCustomAttributes(typeof(DefaultDateTimeValueAttribute), false)
                    ?.Cast<DefaultDateTimeValueAttribute>()
                    ?.FirstOrDefault();
    
                return attribute.GetDefaultValue();
            }
    
            private DateTime GetDefaultValue()
            {
                // Resolve a named property of DateTime, like "Now"
                if (this.IsProperty)
                {
                    return GetPropertyValue();
                }
    
                // Resolve a named extension method of DateTime, like "LastOfMonth"
                if (this.IsExtensionMethod)
                {
                    return GetExtensionMethodValue();
                }
    
                // Parse a relative date
                if (this.IsRelativeValue)
                {
                    return GetRelativeValue();
                }
    
                // Parse an absolute date
                return GetAbsoluteValue();
            }
    
            private bool IsProperty
                => typeof(DateTime).GetProperties()
                    .Select(p => p.Name).Contains(this.DefaultValue);
    
            private bool IsExtensionMethod
                => typeof(DefaultDateTimeValueAttribute).Assembly
                    .GetType(typeof(DefaultDateTimeExtensions).FullName)
                    .GetMethods()
                    .Where(m => m.IsDefined(typeof(ExtensionAttribute), false))
                    .Select(p => p.Name).Contains(this.DefaultValue);
    
            private bool IsRelativeValue
                => this.DefaultValue.Contains(":");
    
            private DateTime GetPropertyValue()
            {
                var instance = Activator.CreateInstance<DateTime>();
                var value = (DateTime)instance.GetType()
                    .GetProperty(this.DefaultValue)
                    .GetValue(instance);
    
                return value;
            }
    
            private DateTime GetExtensionMethodValue()
            {
                var instance = Activator.CreateInstance<DateTime>();
                var value = (DateTime)typeof(DefaultDateTimeValueAttribute).Assembly
                    .GetType(typeof(DefaultDateTimeExtensions).FullName)
                    .GetMethod(this.DefaultValue)
                    .Invoke(instance, new object[] { DateTime.Now });
    
                return value;
            }
    
            private DateTime GetRelativeValue()
            {
                TimeSpan timeSpan;
                if (!TimeSpan.TryParse(this.DefaultValue, out timeSpan))
                {
                    return default(DateTime);
                }
    
                return DateTime.Now.Add(timeSpan);
            }
    
            private DateTime GetAbsoluteValue()
            {
                DateTime value;
                if (!DateTime.TryParse(this.DefaultValue, out value))
                {
                    return default(DateTime);
                }
    
                return value;
            }
        }
    }

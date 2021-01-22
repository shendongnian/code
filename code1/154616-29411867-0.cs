    public static class PropertyNameHelper
    {
        /// <summary>
        /// A static method to get the Propertyname String of a Property
        /// It eliminates the need for "Magic Strings" and assures type safety when renaming properties.
        /// See: http://stackoverflow.com/questions/2820660/get-name-of-property-as-a-string
        /// </summary>
        /// <example>
        /// // Static Property
        /// string name = PropertyNameHelper.GetPropertyName(() => SomeClass.SomeProperty);
        /// // Instance Property
        /// string name = PropertyNameHelper.GetPropertyName(() => someObject.SomeProperty);
        /// </example>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyLambda"></param>
        /// <returns></returns>
        public static string GetPropertyName<T>(Expression<Func<T>> propertyLambda)
        {
            var me = propertyLambda.Body as MemberExpression;
            if (me == null)
            {
                throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }
            return me.Member.Name;
        }
        /// <summary>
        /// Another way to get Instance Property names as strings.
        /// With this method you don't need to create a instance first.
        /// See the example.
        /// See: https://handcraftsman.wordpress.com/2008/11/11/how-to-get-c-property-names-without-magic-strings/
        /// </summary>
        /// <example>
        /// string name = PropertyNameHelper((Firma f) => f.Firmenumsatz_Waehrung);
        /// </example>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string GetPropertyName<T, TReturn>(Expression<Func<T, TReturn>> expression)
        {
            MemberExpression body = (MemberExpression)expression.Body;
            return body.Member.Name;
        }
    }

    /// <summary>
    /// Provides extension methods to determine if objects are equal.
    /// </summary>
    public static class EqualsEx
    {
        /// <summary>
        /// The <see cref="Type"/> of <see cref="string"/>.
        /// </summary>
        private static readonly Type StringType = typeof(string);
        /// <summary>
        /// The <see cref="Type"/> of <see cref="object"/>.
        /// </summary>
        private static readonly Type ObjectType = typeof(object);
        /// <summary>
        /// The <see cref="Type"/> of <see cref="IEquatable{T}"/>.
        /// </summary>
        private static readonly Type EquatableType = typeof(IEquatable<>);
        /// <summary>
        /// Determines whether <paramref name="thisObject"/> is equal to <paramref name="otherObject"/>.
        /// </summary>
        /// <param name="thisObject">
        /// This object.
        /// </param>
        /// <param name="otherObject">
        /// The other object.
        /// </param>
        /// <returns>
        /// True, if they are equal, otherwise false.
        /// </returns>
        public static bool IsEqualTo(this object thisObject, object otherObject)
        {
            if (Equals(thisObject, otherObject))
            {
                // Always check Equals first. If the object has overridden Equals, use it. This will also capture the case where both are the same reference.
                return true;
            }
            if (thisObject == null)
            {
                // Because Equals(object, object) returns true if both are null, if either is null, return false.
                return false;
            }
            var thisObjectType = thisObject.GetType();
            var equalsMethod = thisObjectType.GetMethod("Equals", BindingFlags.Public | BindingFlags.Instance, null, new[] { ObjectType }, null);
            if (equalsMethod.DeclaringType == thisObjectType)
            {
                // thisObject overrides Equals, and we have already failed the Equals test, so return false.
                return false;
            }
            var otherObjectType = otherObject == null ? null : otherObject.GetType();
            // If thisObject inherits from IEquatable<>, and otherObject can be passed into its Equals method, use it.
            var equatableTypes = thisObjectType.GetInterfaces().Where(                                          // Get interfaces of thisObjectType that...
                i => i.IsGenericType                                                                            // ...are generic...
                && i.GetGenericTypeDefinition() == EquatableType                                                // ...and are IEquatable of some type...
                && (otherObjectType ==  null || i.GetGenericArguments()[0].IsAssignableFrom(otherObjectType))); // ...and otherObjectType can be assigned to the IEquatable's type.
            if (equatableTypes.Any())
            {
                // If we found any interfaces that meed our criteria, invoke the Equals method for each interface.
                // If any return true, return true. If all return false, return false.
                return equatableTypes
                    .Select(equatableType => equatableType.GetMethod("Equals", BindingFlags.Public | BindingFlags.Instance))
                    .Any(equatableEqualsMethod => (bool)equatableEqualsMethod.Invoke(thisObject, new[] { otherObject }));
            }
            if (thisObjectType != StringType && thisObject is IEnumerable && otherObject is IEnumerable)
            {
                // If both are IEnumerable, check their items.
                var thisEnumerable = ((IEnumerable)thisObject).Cast<object>();
                var otherEnumerable = ((IEnumerable)otherObject).Cast<object>();
                return thisEnumerable.SequenceEqual(otherEnumerable, IsEqualToComparer.Instance);
            }
            if (thisObjectType != otherObjectType)
            {
                // If they have different types, they cannot be equal.
                return false;
            }
            if (thisObjectType.IsValueType || thisObjectType == StringType)
            {
                // If it is a value type, we have already determined that they are not equal, so return false.
                return false;
            }
            // Recurse into each public property: if any are not equal, return false. If all are true, return true.
            return !(from propertyInfo in thisObjectType.GetProperties()
                     let thisPropertyValue = propertyInfo.GetValue(thisObject, null)
                     let otherPropertyValue = propertyInfo.GetValue(otherObject, null)
                     where !thisPropertyValue.IsEqualTo(otherPropertyValue)
                     select thisPropertyValue).Any();
        }
        /// <summary>
        /// A <see cref="IEqualityComparer{T}"/> to be used when comparing sequences of collections.
        /// </summary>
        private class IsEqualToComparer : IEqualityComparer<object>
        {
            /// <summary>
            /// The singleton instance of <see cref="IsEqualToComparer"/>.
            /// </summary>
            public static readonly IsEqualToComparer Instance;
            /// <summary>
            /// Initializes static members of the <see cref="EqualsEx.IsEqualToComparer"/> class.
            /// </summary>
            static IsEqualToComparer()
            {
                Instance = new IsEqualToComparer();
            }
            /// <summary>
            /// Prevents a default instance of the <see cref="EqualsEx.IsEqualToComparer"/> class from being created.
            /// </summary>
            private IsEqualToComparer()
            {
            }
            /// <summary>
            /// Determines whether the specified objects are equal.
            /// </summary>
            /// <param name="x">
            /// The first object to compare.
            /// </param>
            /// <param name="y">
            /// The second object to compare.
            /// </param>
            /// <returns>
            /// true if the specified objects are equal; otherwise, false.
            /// </returns>
            bool IEqualityComparer<object>.Equals(object x, object y)
            {
                return x.IsEqualTo(y);
            }
            /// <summary>
            /// Not implemented - throws an <see cref="NotImplementedException"/>.
            /// </summary>
            /// <param name="obj">
            /// The <see cref="object"/> for which a hash code is to be returned.
            /// </param>
            /// <returns>
            /// A hash code for the specified object.
            /// </returns>
            int IEqualityComparer<object>.GetHashCode(object obj)
            {
                throw new NotImplementedException();
            }
        }
    }

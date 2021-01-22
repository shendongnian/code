        /// <summary>
        /// [ <c>public static bool IsObjectSetToDefault(this Type ObjectType, object ObjectValue)</c> ]
        /// <para></para>
        /// Reports whether a value of type T (or a null reference of type T) contains the default value for that Type
        /// </summary>
        /// <remarks>
        /// Reports whether the object is empty or unitialized for a reference type or nullable value type (i.e. is null) or 
        /// whether the object contains a default value for a non-nullable value type (i.e. int = 0, bool = false, etc.)
        /// <para></para>
        /// NOTE: For non-nullable value types, this method introduces a boxing/unboxing performance penalty.
        /// </remarks>
        /// <param name="ObjectType">Type of the object to test</param>
        /// <param name="ObjectValue">The object value to test, or null for a reference Type or nullable value Type</param>
        /// <returns>
        /// true = The object contains the default value for its Type.
        /// <para></para>
        /// false = The object has been changed from its default value.
        /// </returns>
        public static bool IsObjectSetToDefault(this Type ObjectType, object ObjectValue)
        {
            // If no ObjectType was supplied, attempt to determine from ObjectValue
            if (ObjectType == null)
            {
                // If no ObjectValue was supplied, abort
                if (ObjectValue == null)
                {
                    MethodBase currmethod = MethodInfo.GetCurrentMethod();
                    string ExceptionMsgPrefix = currmethod.DeclaringType + " {" + currmethod + "} Error:\n\n";
                    throw new ArgumentNullException(ExceptionMsgPrefix + "Cannot determine the ObjectType from a null Value");
                }
                // Determine ObjectType from ObjectValue
                ObjectType = ObjectValue.GetType();
            }
            // Get the default value of type ObjectType
            object Default = ObjectType.GetDefault();
            // If a non-null ObjectValue was supplied, compare Value with its default value and return the result
            if (ObjectValue != null)
                return ObjectValue.Equals(Default);
            // Since a null ObjectValue was supplied, report whether its default value is null
            return Default == null;
        }

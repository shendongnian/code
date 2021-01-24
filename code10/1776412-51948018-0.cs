    public static class CompareObject
        {
            /// <summary>
            /// Compares the properties of two objects of the same type and returns if all properties are equal.
            /// </summary>
            /// <param name="objectA">The first object to compare.</param>
            /// <param name="objectB">The second object to compre.</param>
            /// <param name="ignoreList">A list of property names to ignore from the comparison.</param>
            /// <returns><c>true</c> if all property values are equal, otherwise <c>false</c>.</returns>
            public static Dictionary<string,object> AreObjectsEqual(object objectA, object objectB, params string[] ignoreList)
            {
                //bool result;
                var list = new Dictionary<string, object>();
                if (objectA != null && objectB != null)
                {
                    Type objectType;
                    objectType = objectA.GetType();
                    //result = true; // assume by default they are equal
                    foreach (PropertyInfo propertyInfo in objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead && !ignoreList.Contains(p.Name)))
                    {
                        // if it is a primative type, value type or implements IComparable, just directly try and compare the value
                        if (CanDirectlyCompare(propertyInfo.PropertyType))
                        {
                            object valueA;
                            object valueB;
                            valueA = propertyInfo.GetValue(objectA, null);
                            valueB = propertyInfo.GetValue(objectB, null);
                            if (!AreValuesEqual(valueA, valueB))
                            {
                                list.Add(propertyInfo.Name, valueA);
                                //Console.WriteLine("Mismatch with property '{0}.{1}' found.", objectType.FullName, propertyInfo.Name);
                                //result = false;
                            }
                        }
                    }
                }
                //else
                //    result = object.Equals(objectA, objectB);
                return list;
            }
            /// <summary>
            /// Determines whether value instances of the specified type can be directly compared.
            /// </summary>
            /// <param name="type">The type.</param>
            /// <returns>
            /// 	<c>true</c> if this value instances of the specified type can be directly compared; otherwise, <c>false</c>.
            /// </returns>
            private static bool CanDirectlyCompare(Type type)
            {
                return typeof(IComparable).IsAssignableFrom(type) || type.IsPrimitive || type.IsValueType;
            }
            /// <summary>
            /// Compares two values and returns if they are the same.
            /// </summary>
            /// <param name="valueA">The first value to compare.</param>
            /// <param name="valueB">The second value to compare.</param>
            /// <returns><c>true</c> if both values match, otherwise <c>false</c>.</returns>
            private static bool AreValuesEqual(object valueA, object valueB)
            {
                bool result;
                IComparable selfValueComparer;
                selfValueComparer = valueA as IComparable;
                if (valueA == null && valueB != null || valueA != null && valueB == null)
                    result = false; // one of the values is null
                else if (selfValueComparer != null && selfValueComparer.CompareTo(valueB) != 0)
                    result = false; // the comparison using IComparable failed
                else if (!object.Equals(valueA, valueB))
                    result = false; // the comparison using Equals failed
                else
                    result = true; // match
                return result;
            }
        }

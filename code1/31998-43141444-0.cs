        public static IEnumerable<ObjectPropertyChanged> GetPublicSimplePropertiesChanged<T>(this T previous, T proposedChange,
         string[] namesOfPropertiesToBeIgnored) where T : class
        {
            return GetPublicGenericPropertiesChanged(previous, proposedChange, namesOfPropertiesToBeIgnored, true, null, null);
        }
       
        public static IReadOnlyList<ObjectPropertyChanged> GetPublicGenericPropertiesChanged<T>(this T previous, T proposedChange,
            string[] namesOfPropertiesToBeIgnored) where T : class
        {
            return GetPublicGenericPropertiesChanged(previous, proposedChange, namesOfPropertiesToBeIgnored, false, null, null);
        }
        /// <summary>
        /// Gets the names of the public properties which values differs between first and second objects.
        /// Considers 'simple' properties AND for complex properties without index, get the simple properties of the children objects.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="previous">The previous object.</param>
        /// <param name="proposedChange">The second object which should be the new one.</param>
        /// <param name="namesOfPropertiesToBeIgnored">The names of the properties to be ignored.</param>
        /// <param name="simpleTypeOnly">if set to <c>true</c> consider simple types only.</param>
        /// <param name="parentTypeString">The parent type string. Meant only for recursive call with simpleTypeOnly set to <c>true</c>.</param>
        /// <param name="secondType">when calling recursively, the current type of T must be clearly defined here, as T will be more generic (using base class).</param>
        /// <returns>
        /// the names of the properties
        /// </returns>
        private static IReadOnlyList<ObjectPropertyChanged> GetPublicGenericPropertiesChanged<T>(this T previous, T proposedChange,
            string[] namesOfPropertiesToBeIgnored, bool simpleTypeOnly, string parentTypeString, Type secondType) where T : class
        {
            List<ObjectPropertyChanged> propertiesChanged = new List<ObjectPropertyChanged>();
            if (previous != null && proposedChange != null)
            {
                var type = secondType == null ? typeof(T) : secondType;
                string typeStr = parentTypeString + type.Name + ".";
                var ignoreList = namesOfPropertiesToBeIgnored.CreateList();
                IEnumerable<IEnumerable<ObjectPropertyChanged>> genericPropertiesChanged =
                    from pi in type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    where !ignoreList.Contains(pi.Name) && pi.GetIndexParameters().Length == 0 
                        && (!simpleTypeOnly || simpleTypeOnly && pi.PropertyType.IsSimpleType())
                    let firstValue = type.GetProperty(pi.Name).GetValue(previous, null)
                    let secondValue = type.GetProperty(pi.Name).GetValue(proposedChange, null)
                    where firstValue != secondValue && (firstValue == null || !firstValue.Equals(secondValue))
                    let subPropertiesChanged = simpleTypeOnly || pi.PropertyType.IsSimpleType()
                        ? null
                        : GetPublicGenericPropertiesChanged(firstValue, secondValue, namesOfPropertiesToBeIgnored, true, typeStr, pi.PropertyType)
                    let objectPropertiesChanged = subPropertiesChanged != null && subPropertiesChanged.Count() > 0
                        ? subPropertiesChanged
                        : (new ObjectPropertyChanged(proposedChange.ToString(), typeStr + pi.Name, firstValue.ToStringOrNull(), secondValue.ToStringOrNull())).CreateList()
                    select objectPropertiesChanged;
                if (genericPropertiesChanged != null)
                {   // get items from sub lists
                    genericPropertiesChanged.ForEach(a => propertiesChanged.AddRange(a));
                }
            }
            return propertiesChanged;
        }

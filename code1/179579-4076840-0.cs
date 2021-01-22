    using System.Globalization;
    using System.Reflection;
    /// <summary>
    ///     Resolves concatenated property names back to their originating properties.
    /// </summary>
    /// <remarks>
    ///     An example of a concatenated property name is "ProductNameLength" where the originating
    ///     property would be "Product.Name.Length".
    /// </remarks>
    public static class ConcatenatedPropertyNameResolver
    {
        private static readonly object mappingCacheLock = new object();
        private static readonly Dictionary<MappingCacheKey, string> mappingCache = new Dictionary<MappingCacheKey, string>();
        /// <summary>
        ///     Returns the nested name of the property the specified concatenated property
        ///     originates from.
        /// </summary>
        /// <param name="concatenatedPropertyName">
        ///     The concatenated property name.
        /// </param>
        /// <typeparam name="TSource">
        ///     The mapping source type.
        /// </typeparam>
        /// <typeparam name="TDestination">
        ///     The mapping destination type.
        /// </typeparam>
        /// <returns>
        ///     The nested name of the originating property where each level is separated by a dot.
        /// </returns>
        public static string GetOriginatingPropertyName<TSource, TDestination>(string concatenatedPropertyName)
        {
            if (concatenatedPropertyName == null)
            {
                throw new ArgumentNullException("concatenatedPropertyName");
            }
            else if (concatenatedPropertyName.Length == 0)
            {
                throw new ArgumentException("Cannot be empty.", "concatenatedPropertyName");
            }
            lock (mappingCacheLock)
            {
                MappingCacheKey key = new MappingCacheKey(typeof(TSource), typeof(TDestination), concatenatedPropertyName);
                if (!mappingCache.ContainsKey(key))
                {
                    BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public;
                    List<string> result = new List<string>();
                    Type type = typeof(TSource);
                    while (concatenatedPropertyName.Length > 0)
                    {
                        IEnumerable<PropertyInfo> properties = type.GetProperties(bindingFlags).Where(
                            n => concatenatedPropertyName.StartsWith(n.Name)).ToList();
                        if (properties.Count() == 1)
                        {
                            string match = properties.First().Name;
                            result.Add(match);
                            concatenatedPropertyName = concatenatedPropertyName.Substring(match.Length);
                            type = type.GetProperty(match, bindingFlags).PropertyType;
                        }
                        else if (properties.Any())
                        {
                            throw new InvalidOperationException(
                                string.Format(
                                    CultureInfo.InvariantCulture,
                                    "Ambiguous properties found for {0} on type {1}: {2}.",
                                    concatenatedPropertyName,
                                    typeof(TSource).FullName,
                                    string.Join(", ", properties.Select(n => n.Name))));
                        }
                        else
                        {
                            throw new InvalidOperationException(
                                string.Format(
                                    CultureInfo.InvariantCulture,
                                    "No matching property found for {0} on type {1}.",
                                    concatenatedPropertyName,
                                    typeof(TSource).FullName));
                        }
                    }
                    mappingCache.Add(key, string.Join(".", result));
                }
                return mappingCache[key];
            }
        }
        /// <summary>
        ///     A mapping cache key.
        /// </summary>
        private struct MappingCacheKey
        {
            /// <summary>
            ///     The source type.
            /// </summary>
            public Type SourceType;
            /// <summary>
            ///     The destination type the source type maps to. 
            /// </summary>
            public Type DestinationType;
            /// <summary>
            ///     The name of the mapped property.
            /// </summary>
            public string MappedPropertyName;
            /// <summary>
            ///     Initializes a new instance of the <see cref="MappingCacheKey"/> class.
            /// </summary>
            /// <param name="sourceType">
            ///     The source type.
            /// </param>
            /// <param name="destinationType">
            ///     The destination type the source type maps to.
            /// </param>
            /// <param name="mappedPropertyName">
            ///     The name of the mapped property.
            /// </param>
            public MappingCacheKey(Type sourceType, Type destinationType, string mappedPropertyName)
            {
                SourceType = sourceType;
                DestinationType = destinationType;
                MappedPropertyName = mappedPropertyName;
            }
        }
    }

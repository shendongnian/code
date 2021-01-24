    public class CachingPropProvider {
    /// <summary>
    /// Holds the meta information for each type.
    /// </summary>
    private static readonly ConcurrentDictionary<Type, List<MetaInfo>> TypeCache;
    /// <summary>
    /// Static constructor is guaranteed to run only once.
    /// </summary>
    static CachingPropProvider() {
        //Initialize the cache.
        TypeCache = new ConcurrentDictionary<Type, List<MetaInfo>>();
    }
    /// <summary>
    /// Gets the MetaInfo for the given type. Since We use ConcurrentDictionary it is thread safe.
    /// </summary>
    /// <typeparam name="T">Type parameter</typeparam>
    public static IEnumerable<MetaInfo> GetCachedStuff<T>() {
        //If Type exists in the TypeCache, return the cached value
        return TypeCache.GetOrAdd(typeof(T),Factory);
    }
    /// <summary>
    /// Factory method to use to extract MetaInfo when Cache is not hit.
    /// </summary>
    /// <param name="type">Type to extract info from</param>
    /// <returns>A list of MetaInfo. An empty List, if no property has XlsxColumn attrbiute</returns>
    private static List<MetaInfo> Factory(Type @type) {
        //If Type does not exist in the TypeCahce runs Extractor
        //Method to extract metainfo for the given type
        return @type.GetProperties().Aggregate(new List<MetaInfo>(), Extractor);
    }
    /// <summary>
    /// Extracts MetaInfo from the given property info then saves it into the list.
    /// </summary>
    /// <param name="seedList">List to save metainfo into</param>
    /// <param name="propertyInfo">PropertyInfo to try to extract info from</param>
    /// <returns>List of MetaInfo</returns>
    private static List<MetaInfo> Extractor(List<MetaInfo> seedList,PropertyInfo propertyInfo) {
        //Gets Attribute
        var customattribute = propertyInfo.GetCustomAttribute<XlsxColumn>();
        //If custom attribute is not null, it means it is defined
        if (customattribute != null)
        {
            //Extract then add it into seed list
            seedList.Add(new MetaInfo(propertyInfo, customattribute));
        }
        //Return :)
        return seedList;
    }
    }

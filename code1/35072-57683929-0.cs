    static ConcurrentDictionary<Type, List<CultureInfo>> __resourceCultures = new ConcurrentDictionary<Type, List<CultureInfo>>();
    
    /// <summary>
    /// Return the list of cultures that is supported by a Resource Assembly (usually collection of resx files).
    /// </summary>
    static public List<CultureInfo> CulturesOfResource<T>()
    {
        return __resourceCultures.GetOrAdd(typeof(T), (t) =>
        {
            ResourceManager manager = new ResourceManager(t);
            return CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Where(c => !c.Equals(CultureInfo.InvariantCulture) && 
                            manager.GetResourceSet(c, true, false) != null)
                .ToList();
        });
    }

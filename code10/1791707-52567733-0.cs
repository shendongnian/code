    /// <summary>
    /// Represents the field that
    /// contain the AsyncPackage
    /// instance.
    /// </summary>
    protected AsyncPackage AsyncPackage { get; set; }
    
    /// <summary>
    /// Represents the method that
    /// retrieve the service with
    /// the passed type.
    /// </summary>
    public async Task<T> GetServiceByTypeAsync<T>() where T : class
    {
        return await AsyncPackage.GetServiceAsync(typeof(T)) as T;
    }

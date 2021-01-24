    public enum LicenseStatus
    {
        Unknown = 0,
        Trial,
        Full
    }
    private static StoreContext _context;
    public static async Task<(string storeId, LicenseStatus status, DateTimeOffset acquiredDate)[]> GetSubscriptionAddonStatusesAsync()
    {
        if (_context is null)
            _context = StoreContext.GetDefault();
        StoreProductQueryResult queryResult = await _context.GetUserCollectionAsync(new[] { "Durable" });
        if (queryResult.ExtendedError != null)
            throw queryResult.ExtendedError;
        IEnumerable<(string, LicenseStatus, DateTimeOffset)> Enumerate()
        {
            foreach (KeyValuePair<string, StoreProduct> pair in queryResult.Products)
            {
                StoreSku sku = pair.Value.Skus.FirstOrDefault();
                StoreCollectionData data = sku?.CollectionData;
                if (data != null)
                {
                    LicenseStatus status = data.IsTrial ? LicenseStatus.Trial : LicenseStatus.Full;
                    yield return (pair.Key, status, data.AcquiredDate);
                }
            }
        }
        return Enumerate().ToArray();
    }

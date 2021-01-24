    public static class SyncManagerExt
    {
        // Register is just Add to collection
        public static Task SyncNowAsync(this ICollection<T> items) where T : IOfflineBackedRepo
        {
            // loops through items and calls SyncAsync on the repo
        }
    }

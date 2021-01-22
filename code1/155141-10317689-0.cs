        private static void DeleteLater(string path)
        {
            HttpContext.Current.Cache.Add(path, path, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 8, 0, 0), CacheItemPriority.NotRemovable, UploadedFileCacheCallback);
        }
        private static void UploadedFileCacheCallback(string key, object value, CacheItemRemovedReason reason)
        {
            var path = (string) value;
            Debug.WriteLine(string.Format("Deleting upladed file '{0}'", path));
            File.Delete(path);
        }

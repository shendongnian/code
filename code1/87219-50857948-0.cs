    public static async Task<IStorageItem> AsIStorageItemAsync(this string iStorageItemPath)
        {
            if (string.IsNullOrEmpty(iStorageItemPath)) return null;
            IStorageItem storageItem = null;
            try
            {
                storageItem = await StorageFolder.GetFolderFromPathAsync(iStorageItemPath);
                if (storageItem != null) return storageItem;
            } catch { }
            try
            {
                storageItem = await StorageFile.GetFileFromPathAsync(iStorageItemPath);
                if (storageItem != null) return storageItem;
            } catch { }
            return storageItem;
        }

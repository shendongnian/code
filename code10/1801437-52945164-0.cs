    public IsolatedStorageFile getIsolatedStorage() {
        return AppDomain.CurrentDomain.ActivationContext == null
            ? IsolatedStorageFile.GetUserStoreForAssembly()
            : IsolatedStorageFile.GetUserStoreForApplication();
    }

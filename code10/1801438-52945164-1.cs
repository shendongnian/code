    public IsolatedStorageFile getIsolatedStorage() {
        return System.Deployment.Application.ApplicationDeployment.IsNetwor‌​kDeployed
            ? IsolatedStorageFile.GetUserStoreForApplication()
            : IsolatedStorageFile.GetUserStoreForAssembly();
    }

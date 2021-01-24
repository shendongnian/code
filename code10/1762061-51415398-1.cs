        Windows.Management.Deployment.PackageManager packageManager = new Windows.Management.Deployment.PackageManager();
        IEnumerable<Windows.ApplicationModel.Package> packages = (IEnumerable<Windows.ApplicationModel.Package>)packageManager.FindPackages();
        foreach(var pkg in packages)
        {
            var version = pkg.Id.Version;
            Debug.WriteLine(string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision));
        }

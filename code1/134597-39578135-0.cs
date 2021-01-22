    IPackageRepository sourceRepository = PackageRepositoryFactory.Default.CreateRepository("https://www.nuget.org/api/v2/");
    PackageManager packageManager = new PackageManager(sourceRepository, temporaryDirectory);
    packageManager.PackageInstalled += HandlePackageInstalled;
    packageManager.InstallPackage("Microsoft.Bcl.Immutable", SemanticVersion.Parse("1.0.34"));
    packageManager.InstallPackage("System.Collections.Immutable", SemanticVersion.Parse("1.1.33-beta"));
    using (PEReader referenceAssembly = new PEReader(File.OpenRead(Path.Combine(temporaryDirectory, "Microsoft.Bcl.Immutable.1.0.34", "lib", "portable-net45+win8+wp8+wpa81", "System.Collections.Immutable.dll"))))
    {
        using (PEReader newAssembly = new PEReader(File.OpenRead(Path.Combine(temporaryDirectory, "System.Collections.Immutable.1.1.33-beta", "lib", "portable-net45+win8+wp8+wpa81", "System.Collections.Immutable.dll"))))
        {
            Analyzer analyzer = new Analyzer(referenceAssembly, newAssembly, null);
            analyzer.Run();
        }
    }

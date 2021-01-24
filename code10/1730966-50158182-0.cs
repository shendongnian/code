     private static void ConfigureBindingRedirects()
    {
       BindingRedirect.RedirectAssembly("Microsoft.Owin", new Version("4.0.0"), "31bf3856ad364e35");
    }
    private static void RedirectAssembly(
        string shortName,
        Version targetVersion,
        string publicKeyToken)
    {
        ResolveEventHandler handler = null;
        handler = (sender, args) =>
        {
            var requestedAssembly = new AssemblyName(args.Name);
            if (requestedAssembly.Name != shortName)
            {
                return null;
            }
            var targetPublicKeyToken = new AssemblyName("x, PublicKeyToken=" + publicKeyToken)
                .GetPublicKeyToken();
            requestedAssembly.Version = targetVersion;
            requestedAssembly.SetPublicKeyToken(targetPublicKeyToken);
            requestedAssembly.CultureInfo = CultureInfo.InvariantCulture;
            AppDomain.CurrentDomain.AssemblyResolve -= handler;
            return Assembly.Load(requestedAssembly);
        };
        AppDomain.CurrentDomain.AssemblyResolve += handler;
    }

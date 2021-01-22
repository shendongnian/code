    public static DTE GetCurrentDTE(IServiceProvider provider)
    {
        /*ENVDTE. */DTE vs = (DTE)provider.GetService(typeof(DTE));
            if (vs == null) throw new InvalidOperationException("DTE not found.");
        return vs;
    }
    
    public static DTE GetCurrentDTE()
    {
        return GetCurrentDTE(/* Microsoft.VisualStudio.Shell. */ServiceProvider.GlobalProvider);
    }
            
After that, you can get active Solution from DTE.Solution and you can get Solution path from DTE.Solution.Path property.

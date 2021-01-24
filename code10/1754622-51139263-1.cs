    public static void RegisterBundles(BundleCollection bundles) {
        //... other bundles
    
         bundles.Add(new ScriptBundle("~/bundles/signalr").Include(
            "~/Scripts/jquery.signalr-*", //the * wildcard will get script regardless of version
            "~/signalr/hubs"));
    }

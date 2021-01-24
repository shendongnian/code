    public static void RegisterBundles(BundleCollection bundles)
    {
         StyleBundle bootCss = new StyleBundle("~/styles/bootstrap");
                          bootCss.Include("~/Content/bootstrap/styles/bootstrap.css", 
                          new CssRewriteUrlTransform());
         bootCss.Include("~/Content/bootstrap/styles/bootstrap-theme.min.css", new CssRewriteUrlTransform());
         bundles.Add(bootCss);
    }

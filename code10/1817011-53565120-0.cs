    bundles.Add(new ScriptBundle("~/bundles/brandview").Include(
                    "~/Scripts/Brandview/Brandview.js",
                    "~/Scripts/Brandview/SelectTemplate.js",
                    "~/Scripts/Brandview/DataEntry.js",
                    // "~/Scripts/Brandview/Preview.js",
                    // "~/Scripts/Brandview/ChartCtrl.js",
                    "~/Scripts/Brandview/Submit.js").WithVersionNumber());
        }
        private static Bundle WithVersionNumber(this Bundle sb)
        {
            sb.Transforms.Add(new LastModifiedBundleTransform());
            return sb;
        }
        private class LastModifiedBundleTransform : IBundleTransform
        {
            public void Process(BundleContext context, BundleResponse response)
            {
                var JAVASCRIPT_CSS_VERSION = System.Web.Configuration.WebConfigurationManager.AppSettings["JAVASCRIPT_CSS_VERSION"];
                foreach (var file in response.Files)
                {
                    file.IncludedVirtualPath = string.Concat(file.IncludedVirtualPath, "?v=", JAVASCRIPT_CSS_VERSION);
                }
            }
        }

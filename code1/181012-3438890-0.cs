    SPSecurity.RunWithElevatedPrivileges(() => {
        using (var site = new SPSite("[url]")) {
            using (var web = site.OpenWeb()) {
                // Access list here
            }
            site.RootWeb.Dispose();
        }
    });

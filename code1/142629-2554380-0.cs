    string GetContentFilePath() {
        if(HttpRuntime.AppDomainAppVirtualPath != null) {
            // HTTP runtime is present, so the content file is in the virtual directory.
            return HttpRuntime.AppDomainAppPath;
        } else {
            // HTTP runtime is not present, so the content file is in the same directory as the assembly.
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
    }

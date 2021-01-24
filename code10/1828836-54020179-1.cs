    [HttpGet("[action]")]
    public AppSettings GetAppSettings() {
        var user = this.User;
        var appSettings = new AppSettings {
            //Other settings
            CurrentUser = user.Identity.Name
        };
        return appSettings;
    }

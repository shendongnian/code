    public Service1() {
        string urlSetting = System.Configuration.ConfigurationSettings.AppSettings["WebApplication1.localhost.Service1"];
        if ((urlSetting != null)) {
            this.Url = string.Concat(urlSetting, "");
        }
        else {
            this.Url = "http://localhost/WebService1/Service1.asmx";
        }
    }

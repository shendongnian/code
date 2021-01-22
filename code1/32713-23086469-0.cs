    public void ModifiyValidation(bool validate) {
        var pagesSection = System.Configuration.ConfigurationManager.GetSection("system.web/pages") as PagesSection;
        var httpRuntime = System.Configuration.ConfigurationManager.GetSection("system.web/httpRuntime") as HttpRuntimeSection;
        if (pagesSection != null && httpRuntime != null && pagesSection.ValidateRequest != validate)
        {
            var fi = typeof (ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            fi.SetValue(pagesSection, false);
            fi.SetValue(httpRuntime, false);
            pagesSection.ValidateRequest = validate;
            httpRuntime.RequestValidationMode = new Version(validate ? "4.0" : "2.0");
            fi.SetValue(pagesSection, true);
            fi.SetValue(httpRuntime, true);
        }
    }

    services.AddMvc(options => {
                    foreach (var outputFormatter in 
    options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => 
    _.SupportedMediaTypes.Count == 0))
                    {
                        outputFormatter.SupportedMediaTypes.Add(new 
    MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                    }
                    foreach (var inputFormatter in 
    options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => 
    _.SupportedMediaTypes.Count == 0))
                    {
                        inputFormatter.SupportedMediaTypes.Add(new 
    MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                    }
                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

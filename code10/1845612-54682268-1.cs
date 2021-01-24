    services.AddMvc(config =>
            {
                config.InputFormatters.Insert(0, new XDocumentInputFormatter());
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddXmlSerializerFormatters();

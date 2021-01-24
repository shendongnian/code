            services.AddMvc(options =>
            {
                options.OutputFormatters.RemoveType(typeof(JsonOutputFormatter));
                options.InputFormatters.RemoveType(typeof(JsonInputFormatter));
                options.ReturnHttpNotAcceptable = true;
            })
            .AddXmlSerializerFormatters()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

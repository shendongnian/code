           services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(Version, new Info
                    {
                        Title = Title,
                        Version = Version                        
                    }                
                );
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, $"{_webApiAssemblyName}.xml");
                options.IncludeXmlComments(filePath);
                options.DescribeAllEnumsAsStrings();
    //this is the step where we add the operation filter
                options.OperationFilter<FileUploadOperation>();
            });

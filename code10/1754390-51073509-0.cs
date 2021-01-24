    public static void Register(HttpConfiguration config)
    {
        config
            .EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "version api");                
                c.PrettyPrint();
                c.OAuth2("oauth2").Description("OAuth2 ResourceOwner Grant").TokenUrl("/testtoken");
                c.IncludeXmlComments(GetXmlCommentsPath());
                c.DocumentFilter<AuthTokenOperation>();
                c.DocumentFilter<ListManagementSwagger>();
                c.SchemaFilter<SchemaExamples>();
            })
            .EnableSwaggerUi(c =>
            {
                c.DocumentTitle("test webapi");                
            });
    }

    public static IEdmModel GetImplicitEDM()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder
                .EntitySet<MusicItem>("MusicItems")
                .Page();
            return builder.GetEdmModel();
        }

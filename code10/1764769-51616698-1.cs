    public static class AutoMapperHelper
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            //Load here all your assemblies
            var allClasses = AllClasses.FromLoadedAssemblies();
    
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                if (allClasses != null)
                { 
                    //here normally I add another Profiles that I use with reflection, marking my DTOs with an interface
                    cfg.AddProfile(new MappingModelsAndDtos(allClasses));
                    cfg.AddProfile(new MyCustomProfile());
                }
            });
    
            return config;
        }
    }

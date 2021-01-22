    public class MyProfile : Profile
    {
        public MyProfile()
        {
            ShouldMapProperty = arg => arg.GetMethod.IsPublic || arg.GetMethod.IsAssembly;
            // The mappings here.
        }
    }

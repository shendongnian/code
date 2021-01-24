    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            //put your source and destination here
            CreateMap<MySource, MyDestination>()
                    .ConvertUsing<MySourceToMyDestination<MySource, MyDestination>>();
        }
    }

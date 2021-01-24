      //Profile here is of type AutoMapper.Profile
      public class BusinessLayerMapperConfig : Profile
      {
        public BusinessLayerMapperConfig()
        {
          //create layer specific maps
          CreateMap<MyObjectDTO, MyObjectViewModel>();
        }
    
        public override string ProfileName
        {
          get { return this.GetType().ToString(); }
        }
      }

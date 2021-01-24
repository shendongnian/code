    public class AutoMapperConfigurator:Profile
    {
       
        public AutoMapperConfigurator()
        {
            CreateMap<Customer, Customer>()
                .ForMember(v=>v.Id, opt=>opt.Ignore())
                .ForMember(v=>v.Address,opt=>opt.Ignore())
                ;
        }
    }

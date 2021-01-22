        public class AddressViewModel
        {
                  public string FullAddress{get;set;}
        }
        public class Address
        {
                  public string Street{get;set;}
                  public string Suburb{get;set;}        
                  public string City{get;set;}
        }
        CreateMap<Address, AddressViewModel>()
                 .ForMember( x => x.FullAddress, 
                                  o => o.MapFrom( m => String.Format("{0},{1},{2}"), m.Street, m.Suburb, m.City  ) );
        Address address = new Address(){
            Street = "My Street";
            Suburb= "My Suburb";
            City= "My City";
        };
        AddressViewModel addressViewModel = Mapper.Map(address, Address, AddressViewModel); 

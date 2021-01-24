    //Get customer from db
    var CustomerFromDb= LokaleContext.Set<Customer>().FirstOrDefault(k => k.Id == Customer.Id);
    //Couple the configfile to automapper
     var config = new MapperConfiguration(cfg => {cfg.AddProfile<AutoMapperConfigurator>();});
            IMapper mapper = config.CreateMapper();
    //Map the two objects
            var CustomerforDb= mapper.Map(Customer, CustomerFromDb);
            //Get the address from the Db and couple it to the newly coupled      //entrie
            CustomerforDb.Address= LokaleContext.Set<Address>().SingleOrDefault(k=>k.Id==LichaamsBouw.Klant.Id);
            
            //save in db.
            LokaleContext.SaveChanges();
 

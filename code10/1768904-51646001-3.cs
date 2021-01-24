            public interface ICarRepository 
            {
                 string Get(string id);
                 void DoSomething(ref ISpecial special);
            }
    
     public class BigCarRepository : ICarRepository 
            {
                public ICarRepository _carRepository { get; set; }
            
                public BigCarRepository(ICarRepository carRepository) 
                {
                    _carRepository = carRepository;
                }
            
                public string Get (string id) 
                {
                    return _carRepository.Get(id);
                }
            
                public void DoSomething(ref ISpecial special) {
              
                    special = special.AddFields(SpecialOffer, OptionPack);
                }
            }

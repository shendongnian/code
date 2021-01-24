        public interface ICarRepository 
        {
             string Get(string id);
             void DoSomething(ref ISpecial special);
        }
        
        public abstract class CarRepository : ICarRepository
        {
            private string _model;
            private string _colour;
        
            protected CarRepository(string model, string colour) {
                _model = model;
                _colour = colour
            }
        
            public string Get(GUID id)
            {
                return id.ToString();
            }
        
            public absctract void DoSomething(ref ISpecial special); // Force all derived classes to implement this method
            
           protected virtual void DoSomethingBase(ref ISpecial special) {
                special = special.AddFields(Rego, ModelNumber)
            }
        }
    
    public class BigCarRepository : CarRepository 
    {
        public ICarRepository _carRepository { get; set; }
    
        public BigCarRepository(ICarRepository carRepository) : base (pass_the_model, pass_the_colour)
        {
            _carRepository = carRepository;
        }
    
        public override void DoSomething(ref ISpecial special) {
            DoSomethingBase(ref special); // if you need some base class logic
            special = special.AddFields(SpecialOffer, OptionPack);
        }
    }

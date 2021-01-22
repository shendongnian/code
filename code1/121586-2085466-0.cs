    public interface ICarBasic
    {
        double Speed { get; set; }
    }
    
    public interface ICar : ICarBasic
    {
        FuelType FuelType { get; set; } 
    }

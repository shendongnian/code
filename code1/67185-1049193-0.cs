    public interface ICar
    {
        IWheels Wheel { get; set; }
    }
    public interface IWheels
    {
        IRims Rim { get; set; }
    }

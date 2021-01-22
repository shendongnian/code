    public interface ICar
    {
        IWheels Wheel { get; }
    }
    public interface IWheels
    {
        IRims Rim { get; }
    }

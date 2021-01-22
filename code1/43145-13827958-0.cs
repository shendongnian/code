    public interface IPackable { double Weight { get; } }
    public interface IShipMethod { }
    public class OrderItem : IPackable { }
    public List<IShipMethod> GetForShipWeight<T>(List<T> packages) where T : IPackable
    {
        List<IShipMethod> ship = new List<IShipMethod>();
        foreach (IPackable package in packages)
        {
            // Do something with packages to determine list of shipping methods
        }
        return ship;
    }
    public void Test()
    {
        List<OrderItem> orderItems = new List<OrderItem>();
        // Now compiles...
        List<IShipMethod> shipMethods = GetForShipWeight(orderItems);
    }

    public interface I1
    {
        void AddOrder(Order ord);
    }
    public interface I2
    {
        void ExecuteOrder(Order ord);
    }
    internal class TradingSystem: I1, I2
    {
        ...

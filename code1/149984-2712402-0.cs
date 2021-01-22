    interface I1
    {
        void AddOrder(Order ord);
    }
    interface I2
    {
        void ExecuteOrder(Order ord);
    }
    class TradingSystem: I1, I2
    {
        ...

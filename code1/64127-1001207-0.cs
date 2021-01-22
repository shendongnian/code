    public abstract class DistributerTransaction
    {
        DistributerDA dataaccess;
    }
    public class Indent : DistributerTransaction
    {
    }
    public class Sell : DistributerTransaction
    {
    }
    public class Stock : DistributerTransaction
    {
    }
    public abstract class DistributerDA
    {
       /*Read();
         Update();*/
    }
    public class IndentDA : DistributerDA
    {
    }
    public class SellDA : DistributerDA
    {
    }
    public class StockDA : DistributerDA
    {
    }

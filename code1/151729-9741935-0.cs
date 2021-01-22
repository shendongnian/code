    struct Stock { public string Symbol; public decimal Price;}
    interface IByArray { Stock[] Search(string Field, string Param); }
    interface IByClass { Stocks Search(string Field, string Param); }
    class Stocks : IByArray, IByClass
    {
        Stock[] _stocks = { new Stock { Symbol = "MSFT", Price = 32.83m } };
        Stock[] IByArray.Search(string Field, string Param)
        {
            return _stocks;
        }
        Stocks IByClass.Search(string Field, string Param)
        {
            return this;
        }
    }

    public void SellStock( int clientID, string stockSymbol, int quantityToSell )
    {
         using( var scope = new TransactionScope() )
         {
              // pseudo-sql for reducing client portfolio by quantity
              update ClientStockPortfolio 
              set Quantity = Quantity - quantityToSell 
              where ID = clientID 
              and StockSymbol = stockSymbol
              and Quantity >= quantityToSell 
              // log transaction history and update other tables as needed
         }
    }

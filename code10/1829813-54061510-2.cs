    /// <summary>
    /// Define basic Visitor Interface.
    /// </summary>
    internal interface IVisitor
    {
        void Visit(Book book);
        void Visit(Car car);
        void Visit(Wine wine);
    }
    #region "Visitor Implementation"
    
    
    /// <summary>
    /// Define Visitor of Basic Tax Calculator.
    /// </summary>
    internal class BasicPriceVisitor : IVisitor
    {
        public int taxToPay { get; private set; }
        public int totalPrice { get; private set; }
    
        public void Visit(Book book)
        {
            var calculatedTax = (book.Price * 10) / 100;
            totalPrice += book.Price + calculatedTax;
            taxToPay += calculatedTax;
        }
    
        public void Visit(Car car)
        {
            var calculatedTax = (car.Price * 30) / 100;
            totalPrice += car.Price + calculatedTax;
            taxToPay += calculatedTax;
        }
    
        public void Visit(Wine wine)
        {
            var calculatedTax = (wine.Price * 32) / 100;
            totalPrice += wine.Price + calculatedTax;
            taxToPay += calculatedTax;
        }
    }
    
    
    #endregion "Visitor Implementation"

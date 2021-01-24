      #region "Structure Implementations"
    
    
        /// <summary>
        /// Define base class for all items in products to share some common state or behaviors.
        /// Thic class implement IVisitable,so it allows products to be Visitable.
        /// </summary>
        internal abstract class Product : IVisitable
        {
            public int Price { get; set; }
            public abstract void Accept(IVisitor visit);
        }
    
        /// <summary>
        /// Define Book Class which is of Product type.
        /// </summary>
        internal class Book : Product
        {
            // Book specific data
    
            public Book(int price)
            {
                this.Price = price;
            }
            public override void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
        }
    
        /// <summary>
        /// Define Car Class which is of Product type.
        /// </summary>
        internal class Car : Product
        {
            // Car specific data
    
            public Car(int price)
            {
                this.Price = price;
            }
    
            public override void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
        }
    
        /// <summary>
        /// Define Wine Class which is of Product type.
        /// </summary>
        internal class Wine : Product
        {
            // Wine specific data
            public Wine(int price)
            {
                this.Price = price;
            }
    
            public override void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
        }
    
        #endregion "Structure Implementations"  

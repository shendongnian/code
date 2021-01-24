    /// <summary>
    /// Define Visitable Interface.This is to enforce Visit method for all items in product.
    /// </summary>
    internal interface IVisitable
    {
        void Accept(IVisitor visit);
    }   

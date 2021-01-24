    public static class DslExtensions
    {
        public static IRightHandSideExpression AddToBasket(this IRightHandSideExpression rhs, IFruit apple)
        {
            return rhs.Do(ctx => ctx.Insert(new Basket(apple)));
        }
    }

    public static string Select(this Grid _grid, Expression<Func<Product, bool>> filter = null)
        {
            //filter = {x => (x.ProductID > 1)}
            BinaryExpression be = filter.Body as BinaryExpression;
            //be = {(x.ProductID > 1)}
            return be.ToString();
        }
        

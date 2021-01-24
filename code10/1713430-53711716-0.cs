       public List<Product> Get(string filter = null)
        {
            var p = Expression.Parameter(typeof(Product), "x");
            var e = (Expression)DynamicExpressionParser.ParseLambda(new[] { p }, null, filter);
            var typedExpression = (Expression<Func<Product, bool>>)e;
            var res = _productDal.GetList(typedExpression);
            return res;
        }

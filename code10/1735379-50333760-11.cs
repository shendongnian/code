    public Expression<Func<Product, bool>> Filter {
        get {
            var exprs = new List<Expression<Func<Product, bool>>>() {
                p => p.CategoryId == this.CategoryId,
                p => p.Price >= this.MinPrice,
                p => p.Price <= this.MaxPrice
            }.Where(expr => {
                PropertyInfo mi = ((expr.Body as BinaryExpression)
		            .Right as MemberExpression)
		            .Member as PropertyInfo;
		        return mi.GetValue(this) != null;
		    });
			
            var predicate = PredicateBuilder.True<Product>();
            foreach (var expr in exprs) {
                predicate = predicate.And(expr);
            }
			
            return predicate;
        }
    }

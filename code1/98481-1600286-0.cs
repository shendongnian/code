    using System;
    using System.Linq;
    using System.Linq.Expressions;
    public partial class Product
    {
        public static Expression<Func<Product, string>> Blarg
        {
            get { return product => product.ProductModelID.HasValue ? "Blarg?" : "Blarg!"; }
        }
        public int? ProductModelID { get; set; }
    
        static void Main()
        {
            var lambda = (LambdaExpression)typeof(Product)
              .GetProperty("Blarg").GetValue(null, null);
    
            var productParameter = Expression.Parameter(typeof(Product), "product");
    
            // The Problem
            var groupExpression = Expression.Lambda<Func<Product, string>>(
                Expression.Invoke(
                    lambda,
                    productParameter),
                productParameter);
    
            var data = new[] {
                new Product { ProductModelID = 123},
                new Product { ProductModelID = null},
                new Product { ProductModelID = 456},
            };
            var qry = data.AsQueryable().GroupBy(groupExpression).ToList();
        }
    }

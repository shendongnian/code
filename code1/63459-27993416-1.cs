    public static class MyFunctions {
        [InjectLambda]
        public static bool IsAGoodProduct(Product product) {
            return product.Quality>3;
        }
        public static Expression<Func<Product,bool>> IsAGoodProduct() {
            return (p) => p.Quality>3;
        }
    }

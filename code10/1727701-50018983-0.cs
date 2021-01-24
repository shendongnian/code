     public static Product Clone(Product product)
            {
                return new Product
                {
                    Underlying = product.Underlying
                };
            }

    static class ProductDTO
    {
        public static ProductDTO<N, P, Q> Create<N, P, Q>(N name, P price, Q quantity)
        {
            return new ProductDTO<N, P, Q>(name, price, quantity);
        }
    }

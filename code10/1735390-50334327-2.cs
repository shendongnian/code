    public class ProductQuery
    {
        public int? CategoryId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public IEnumerable<Expression<Func<Product, bool>>> Filters
        {
            get 
            {
                var filters = new List<Expression<Func<Product, bool>>>();
                if (this.CategoryId.HasValue)
                    filters.Add(p => p.CategoryId == this.CategoryId);
                if (this.MinPrice.HasValue)
                    filters.Add((p => p.Price >= this.MinPrice);
                if (this.MaxPrice.HasValue)
                    filters.Add(p => p.Price <= this.MaxPrice);
            
                return filters;
            }
        }
    }

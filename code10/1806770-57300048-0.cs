c#
        private IAggregateFluent<ProductTypeSearchResult> CreateSearchQuery(string query)
        {
            FilterDefinition<ProductType> filter = Builders<ProductType>.Filter.Text(query);
            return _collection
                .Aggregate()
                .Match(filter)
                .AppendStage<ProductType>("{$addFields: {score: {$meta:'textScore'}}}")
                .Sort(Sort)
                .Project(pt => new ProductTypeSearchResult
                {
                    Description = pt.ExternalProductTypeDescription,
                    Id = pt.Id,
                    Name = pt.Name,
                    ProductFamilyId = pt.ProductFamilyId,
                    Url = !string.IsNullOrEmpty(pt.ShopUrl) ? pt.ShopUrl : pt.TypeUrl,
                    Score = pt.Score
                });
        }
Note that `ProductType` does have a `Score` property defined as 
c#
        [BsonIgnoreIfNull]
        public double Score { get; set; }
It's unfortunate that `$addFields` is not directly supported and we have to resort to "magic strings"

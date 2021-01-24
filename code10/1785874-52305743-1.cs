            public async Task<ResultDto<Product>> getAllScheds()
        {
            dynamic response = new JObject();
            try
            {
                var data = new List<Product>
                         {
                             new Product{ProductId=Guid.NewGuid().ToString(),Name="142525"},
                             new Product{ProductId=Guid.NewGuid().ToString(),Name="122555"},
                             new Product{ProductId=Guid.NewGuid().ToString(),Name="125255"}
                         };
                return new ResultDto<Product>("success", data);
            }
            catch (Exception e)
            {
                response.Error = e.ToString();
                return response;
            }
        }

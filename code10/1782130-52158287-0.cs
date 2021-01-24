        public void CallingFunctionToGetProductsAsync() {
            Task.Run(async () =>
            {
                var response = await GetProductsAsync(1);
                ProcessResponse(response);
            });
 
            Task.Run(async () =>
            {
                var response = await GetProductsAsync(2);
                ProcessResponse(response);
            });
        }
 

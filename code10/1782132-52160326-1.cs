    public  async Task<Response> GetProductsAsync(int categoryId, int pageNo = -1, int pageSize = -1)
    {
        try
        {
            string url = "";
            if (pageNo == -1 || pageSize == -1)
                url = $"catalog/v1/categories/{categoryId}/products";
            else
                url = $"catalog/v1/categories/{categoryId}/products?page-number={pageNo}&page-size={pageSize}";
            var response = await client.GetAsync(url).ConfigureAwait(false);
            string responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            GetParsedData(response.IsSuccessStatusCode, responseString);
        }
        catch (Exception e)
        {
            apiResponse.status = "internalError";
            apiResponse.data = e.Message;
        }
        return apiResponse;
    }

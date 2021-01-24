    public async Task<List<Produto>> GetProdutosAsync()
            {
                try
                {
                    string url = "http://www.something.com/api/produtos/";
                    var response = await client.GetStringAsync(url);
                    var produtos = JsonConvert.DeserializeObject<List<Produto>>(response);
                    return produtos;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

    public async Task<ResultCgOrder> createOrder(CgOrder data)
        {
            ResultCgOrder resultCgOrder = new ResultCgOrder();
            string path = "https://api-xxx";
            nonce = Convert.ToString(Stopwatch.GetTimestamp());
            ApiHeaderGet(createHashString());
            var body = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string, string>("order_id", data.OrderId),
                new KeyValuePair<string, string>("price", data.Price.ToString()),               
            }
                );
            var incomingResult =  client.PostAsync(path, body).Result;
            if (incomingResult.IsSuccessStatusCode)
            {
                resultCgOrder = await incomingResult.Content.ReadAsAsync<ResultCgOrder>();
            }
            return resultCgOrder;
        }
 

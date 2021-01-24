    var serializeObject = _jsonSerializer.Serialize(YourClassThatHoldsParams);
    using (var requestContent = new StringContent(serializeObject, System.Text.Encoding.UTF8, "application/json"))
                {
                    using (var responseMessage = await PostAsync(requestUri, requestContent))
                    {
                        response = _jsonSerializer.DeSerialize<TV>(await responseMessage.Content.ReadAsStringAsync());
                    }
                }

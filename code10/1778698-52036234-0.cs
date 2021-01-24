    public async Task<int> GetPredracunBroj()
    {
        int result = 0;
        HttpResponseMessage responseMessage = predracunService.GetActionResponse("GetPredracunBroj");
        if (responseMessage.IsSuccessStatusCode)
        {
            string responseString = await responseMessage.Content.ReadAsStringAsync();
            if (!int.TryParse(responseString, out result))
            {
                throw new ArgumentException($"Argument is not expected format [{responseString}]");
            }
        }
        return result;
    }

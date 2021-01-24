    public static async Task<ResultViewModel<T>> ExecuteAsyncOperation<T>(this Task<HttpResponseMessage> operation, Button button)
    {
        ResultViewModel<T> resultModel = new ResultViewModel<T>();
        try
        {
			if (button != null)
                button.IsEnabled = false;
            HttpResponseMessage RawResult = await operation;
            string Response = await RawResult.Content.ReadAsStringAsync();
            resultModel.Status = RawResult.StatusCode;
            if (RawResult.IsSuccessStatusCode)
            {
                var responseObj = JsonConvert.DeserializeObject<T>(Response);
                resultModel.Result = responseObj;
            }
            else
            {
				//create an error model instead of using dynamic I am guessing modelstate here
                List<ModelState> responseObj = JsonConvert.DeserializeObject<List<ModelState>>(Response);
                resultModel.Errors = new List<string>();
                foreach (ModelState modelState in responseObj)
                {
                    foreach (var error in modelState.Errors)
                    {
                        resultModel.Errors.Add(error.ToString());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            resultModel.Status = HttpStatusCode.InternalServerError;
            resultModel.Errors = new List<string>() { "Some error occurred. Please try again." };
        }
        finally
        {
            if (button != null)
                button.IsEnabled = true;
        }
        return resultModel;
    }

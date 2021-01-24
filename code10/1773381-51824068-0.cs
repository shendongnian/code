     var responseType = typeof(RestErrorResponse<>).MakeGenericType(exceptionType);
     dynamic response = Activator.CreateIntance(type);
     response.Content = null;
     response.Status = RestStatus.Error;
     response.Exception = actionExecutedContext.Exception;

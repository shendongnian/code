    catch (ArgumentException ex)
    {
        WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
        WebOperationContext.Current.OutgoingResponse.StatusDescription = ex.Message;
        return null;
    }

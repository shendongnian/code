    try
    {
        //business logic
        
        //specific exception
        if (verifySongViewModels.NullOrEmpty())
        {
           throw new InvalidDataException();
        }
    }
    catch(Exception ex)
    {
        // return error;
        return Json(new JsonBaseModel
        {
           success = false,
           message = InvalidRequest,
           data = null,
           error = ex.ToString()
        }
    }

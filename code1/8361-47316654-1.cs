    try
    {
        WebId = new Guid(queryString["web"]);
        // More initialization code goes here.
    }
    catch (FormatException) {
        Reset(WebId);
    }
    catch (OverflowException) {
        Reset(WebId);
    }

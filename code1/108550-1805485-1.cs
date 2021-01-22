    try
    {
         service.StartGame();
    }
    catch(SoapHeaderException)
    {
    // soap fault in the header e.g. auth failed
    }
    catch(SoapException x)
    {
    // general soap fault  and details in x.Message
    }
    catch(WebException)
    {
    // e.g. internet is down
    }
    catch(Exception)
    {
    // handles everything else
    }

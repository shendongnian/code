    try
    {
         service.StartGame();
    }
    catch(SoapHeaderException)
    {
    // soap fault in the header e.g. auth failed
    }
    catch(SoapException)
    {
    // general soap fault
    }
    catch(WebException)
    {
    // e.g. internet is down
    }
    catch(Exception)
    {
    // handles everything else
    }

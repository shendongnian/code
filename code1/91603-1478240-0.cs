    try
    {
        // Do some work.
    }
    catch(SocketException ex)
    {
        // Handle a known SocketException
    }
    catch(NullReferenceException ex)
    {
        // Handle a known NullReferenceException
    }
    catch(OtherSpecificException ex)
    {
        // You get the idea
    }
    catch(Exception ex)
    {
        // This will be everything else you haven't explicitly caught.
        // It will also give you the most generic details about the Exception.
    }

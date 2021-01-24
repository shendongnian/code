    try
    {
        throw new TimeoutException();
    }
    catch (Exception e) when (e is ArgumentNullException || e is FormatException)
    {
        //do something
    }
    catch (Exception e) when (e is TimeoutException)
    {
        //do something
    }
    catch (Exception e)
    {
        throw new NotImplementedException($"Hey Mike, write something for {e.GetType()}, will ya?"); //idea from Jeroen
    }

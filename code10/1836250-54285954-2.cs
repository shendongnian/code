    public void HandleException(Action action)
    {
        try
        {
            action();
        }
        catch (Exception1 e)
        {
            // Exception1 handling
        }
        catch (Exception2 e)
        {
            // Exception2 handling
        }
        catch (Exception3 e)
        {
            // Exception3 handling
        }
        catch (Exception e)
        {
            // Exception handling
        }
    }
    ...
    HandleException(() => /* implementation */)

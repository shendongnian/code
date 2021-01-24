    try
    {
        await _next(context);
    }
    catch (Exception ex)
    {
        // …
        try
        {
            // …
            await _options.ExceptionHandler(context);
            // …
            return;
        }
        catch (Exception ex2)
        {
            // Suppress secondary exceptions, re-throw the original.
            _logger.ErrorHandlerException(ex2);
        }
        throw; // Re-throw the original if we couldn't handle it
    }

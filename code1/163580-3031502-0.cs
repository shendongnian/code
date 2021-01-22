    catch (Exception ex)
    {
        Logger.Log(String.Format(
            System.Globalization.CultureInfo.InvariantCulture,
            "An exception is being eaten and not handled. "+
            "This may be hiding critical errors.\n"+
            "Exception: {0}",
            ex));
    }

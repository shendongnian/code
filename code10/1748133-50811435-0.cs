    myReader = myCommand.ExecuteReader();
        try
        {
            bulkcopy.WriteToServer(myReader);
        }
        catch (Exception e)
        {
            Logger.Log("Cannot Import SmartZone Device Data: " + e.Message, true);
        }

    #if DEBUG
    catch(Exception)
    {
         throw;
    }
    #else
    catch(Exception ex)
    {
        Console.WriteLine("exception => " + ex.Message);
    }
    #endif

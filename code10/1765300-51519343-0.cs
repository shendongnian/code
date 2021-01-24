    catch (Exception ex)
    {
        while (ex != null)
        {
            Console.Error.WriteLine(ex.Message);
            ex = ex.InnerException;
        }
    }

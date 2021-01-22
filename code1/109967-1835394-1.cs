    try { ... }
    catch (Exception ex) {
        while(ex != null) {
            Console.WriteLine(ex.Message);
            ex = ex.InnerException;
        }
    }

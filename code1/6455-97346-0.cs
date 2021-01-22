    static void TryCatchFinally()
    {
        StreamReader sr = null;
        try
        {
            sr = new StreamReader(path);
            Console.WriteLine(sr.ReadToEnd());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            if (sr != null)
            {
                sr.Close();
            }
        }
    }

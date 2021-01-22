    }
    catch(OdbcException e)
    {
        for (int i=0; i < e.Errors.Count; i++)
        {
            Console.WriteLine("Index #{0}", i);
            Console.WriteLine("Message: {0}", e.Errors[i].Message);
            Console.WriteLine("NativeError: {0}", e.Errors[i].NativeError.ToString());
            Console.WriteLine("Source: {0}", e.Errors[i].Source);
            Console.WriteLine("SQL: {0}", e.Errors[i].SQLState);
        }
    }

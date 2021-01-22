     try
        {
            using (Foo f = new Foo())
            {
                //some commands that potentially produce exceptions.
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

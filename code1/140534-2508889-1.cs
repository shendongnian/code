    try
    {
        using (var context = new TestDataContext())
        {
            var binarySample2 = new BinarySample
            {
                NonNullImage = null,
                Image = new Binary( new byte[0] )
            };
            context.BinarySamples.InsertOnSubmit( binarySample2 );
            context.SubmitChanges();
        }
    }
    catch (SqlException e)
    {
        Console.WriteLine( e.Message );
    }

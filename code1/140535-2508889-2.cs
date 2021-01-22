    using (var context = new TestDataContext())
    {
        var binarySample = new BinarySample
        {
            Image = null,
            NonNullImage = new Binary( new byte[0] ),
        };
        context.BinarySamples.InsertOnSubmit( binarySample );
        context.SubmitChanges();
    }

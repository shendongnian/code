    try
    {
        Func<int> d = () =>
        {
            try
            {
                return Guid.Parse("*").ToByteArray()[0];
            }
            catch (Exception)
            {
                throw;
            }
        };
        Action a = () => { String.Format("{0}", 1 / d()); };
        a();
    }
    catch (Exception ex)
    {
        var useful = ex.TryGetExceptionOrigin(null, null, 0);
    }

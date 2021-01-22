    public static void VerifierException<T>(Action action) where T : Exception
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            Assert.IsInstanceOfType(ex, typeof(T));
            return;
        }
        Assert.Fail("Aucune exception n'a été déclenchée alors qu'une exception du type " + typeof(T).FullName + " était attendue");
    }

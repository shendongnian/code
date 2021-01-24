    [Preserve]
    public static class LinkerPreserve
    {
        static LinkerPreserve()
        {
            throw new Exception(typeof(My.Library.SomeManager).FullName);
        }
    }

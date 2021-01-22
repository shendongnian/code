    private static IEnumerable<SomeType> GetSomeData(string someInput)
    {
        IEnumerable<SomeType> result = null;
        using (SqlConnection conn = new SqlConnection(GetConnectionString()))
        {
            // put whatever code is needed to populate the result here
        }
        return result;
    }

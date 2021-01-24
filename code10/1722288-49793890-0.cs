    public stBusinessTerm GetBusinessTerm(string termName)
    {
        using(var conn = GetConnectionFromSomewhere())
        {
            return conn.QuerySingleOrDefault<stBusinessTerm>(@"
    Select * From [MetadataRepository].[dbo].[QrySocialGraphMobile]
    Where BusinessTerm = @termName",
                new { termName }); // parameters
        }
    }

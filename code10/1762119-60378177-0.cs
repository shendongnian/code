    public interface IApiHgFinance
    {
        [Get("/taxes?key=minhachave")]
        Task<string> GetTaxes();
    }

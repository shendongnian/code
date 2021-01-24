    //separate assembly
    public interface IDbEningeSelector
    {
        //added the option builder for simplicity: one could do better.
        void Configure(string connectionString,IOptionsBuilder optionsBuilder);
    }

    /// Assuming a non-generic interface
    public interface ISomething
    {
        /// Assuming the return-type differs from the input-type
        TOutput GetResponseData<TOutput, TInput>(TInput response);
        /// Assuming the return-type should match the input-type
        T GetResponseData<T>(T response);
    }
    /// Assuming a Generic interface, differing types
    public interface ISomething<TOutput, TInput>
    {
        /// Assuming the return-type differs from the input-type
        TOutput GetResponseData(TInput response);
    }
    /// Assuming a Generic interface, matching return/input types
    public interface ISomething<T>
    {
        /// Assuming the return-type differs from the input-type
        T GetResponseData(T response);
    }

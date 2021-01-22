    class Result<T>
    {
        private Result(bool isError, T value, List<Error> erors) { }
        public Result(T value) : this(false, value, null){ }
        public Result(List<Error> errors) : this(true, default(T), errors) { }
    }
    class SomeExceptionBase : Exception
    {
        public List<Error> ErrorList { get; private set; }
    }

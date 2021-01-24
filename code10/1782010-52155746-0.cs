    interface IAddResult
    {
        int AddendA { get; set; }
        int AddendB { get; set; }
        int Sum { get; }
    }
    
    static class Result
    {
        public static IAddResult OfAdding(int a, int b)
        {
            // TODO: Return add result.
            throw new NotImplementedException();
        }
    }

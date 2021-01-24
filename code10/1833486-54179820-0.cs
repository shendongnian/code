    public static class LongCalculationExtensions
    {
        public static ILongCalculationResult ThrowIfHasError(this ILongCalculationResult result)
        {
           if(result.HasError) throw new Exception("Your exception here");
    
           return result;
        }
    }

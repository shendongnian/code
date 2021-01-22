    public static class MapperExtensions
    {
        public static IEnumerable<TOutput> MapAll<TInput, TOutput>(this IMapper<TInput, TOutput> mapper, IEnumerable<TInput> input)
        {
            return input.Select(x => mapper.Map(x));
        }
    }

    public static class LinqExtension
    {
        public static IEnumerable<ViewModel> ToViewModel(this IEnumerable<Entity> source)
        {
            // your own conversion from Entity to ViewModel
            return result;
        }
    }

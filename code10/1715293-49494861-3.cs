    public static class Helper
    {
        public static IEnumerable<T> Rotate<T>(this IEnumerable<T> elements, int number)
        {
            var elemetsList = elements as IList<T> ?? elements.ToList();
            if (number > elemetsList.Count - 1)
            {
                throw new ArgumentException(nameof(number));
            }
            for (int i = number; i < elemetsList.Count; i++)
            {
                yield return elemetsList[i];
            }
            for (int i = 0; i < number; i++)
            {
                yield return elemetsList[i];
            }
        }
    }

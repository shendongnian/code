        public static IEnumerable<T> Rotate<T>(this IEnumerable<T> elements, int number)
        {
            var elemetsList = elements as IList<T> ?? elements.ToList();
            var list = new List<T>(elemetsList.Count);
            
            if (number > elemetsList.Count - 1)
            {
                throw new ArgumentException(nameof(number));
            }
            for (int i = number; i < elemetsList.Count; i++)
            {
                list.Add(elemetsList[i]);
            }
            for (int i = 0; i < number; i++)
            {
                list.Add(elemetsList[i]);
            }
            return list;
        }

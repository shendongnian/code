        public static ICollection<T> RandomObjects<T>(IList<T> objectSet, int amount)
        {
            var resultSet = new HashSet<T>();
            var random = new Random();
            amount = Math.Min(objectSet.Count, amount);
            while (resultSet.Count<amount)
            {
                resultSet.Add(objectSet[random.Next(amount)]);
            }
            return resultSet;
        }
	

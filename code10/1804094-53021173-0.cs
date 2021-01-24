      public static bool NotIn(this string filter , params string[] valuesToCompare)
        {
            var result = true;
            foreach (var item in valuesToCompare)
            {
                if (filter == item) return false;
            }
            return result;
        }

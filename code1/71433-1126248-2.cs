        private static IEnumerable<T> MyEnum(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

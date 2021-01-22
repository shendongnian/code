        public static IEnumerable GetRemoveSafeEnumerator(this ArrayList list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                // Reset the value of i if it is invalid.
                // This occurs when more than one item
                // is removed from the list during the enumeration.
                if (i >= list.Count)
                {
                    if (list.Count == 0)
                        yield break;
                    i = list.Count - 1;
                }
                yield return list[i];
            }
        }

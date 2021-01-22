       private static void CheckForDuplicateItems(List<string> items)
        {
            if (items == null ||
                items.Count == 0)
                return;
            for (int outerIndex = 0; outerIndex < items.Count; outerIndex++)
            {
                for (int innerIndex = 0; innerIndex < items.Count; innerIndex++)
                {
                    if (innerIndex == outerIndex) continue;
                    if (items[outerIndex].Equals(items[innerIndex]))
                    {
                        // Duplicate Found
                    }
                }
            }
        }

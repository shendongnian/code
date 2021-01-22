    public static int IndexOfAny(this string str, string[] values, int startIndex, out string selectedItem)
        {
            int first = -1;
            selectedItem = null;
            foreach (string item in values)
            {
                int i = str.IndexOf(item, startIndex, StringComparison.OrdinalIgnoreCase);
                if (i >= 0)
                {
                    if (first > 0)
                    {
                        if (i < first)
                        {
                            first = i;
                            selectedItem = item;
                        }
                    }
                    else
                    {
                        first = i;
                        selectedItem = item;
                    }
                }
            }
            return first;
        }

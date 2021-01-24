        public bool Remove(T toRemove)
        {
            bool result = false;
            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(toRemove))
                {
                    int removeIndex = i;
                    for (int j = removeIndex; j < count - 1; j++)
                    {
                        items[j] = items[j + 1];
                    }
                    result = true;
                }
            }
            return result;
        }

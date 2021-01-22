    public bool ContainAnyOf(string word, string[] array) 
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (word.Contains(array[i]))
                {
                    return true;
                }
            }
            return false;
        }

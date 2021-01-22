    public List<T> Rotate<T>(List<T> list, int shift)
    {
        int j = 0;
        List<T> temp_buffer = new List<T>();
        for (int i = 0; i < list.Count; i++)
        {
            if (i < shift)
            {
                temp_buffer.Add(list[i]);
            }
            if (i < paths.Count - shift)
            {
                list[i] = list[i + shift];
            }
            else
            {
                list[i] = temp_buffer[j];
                j++;
            }
        }
        return list;
    }

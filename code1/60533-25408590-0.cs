    public   static   T[]   SubArray<T>(T[] data, int index, int length)
            {
                List<T> retVal = new List<T>();
                if (data == null || data.Length == 0)
                    return retVal.ToArray();
                bool startRead = false;
                int count = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    if (i == index && !startRead)
                        startRead = true;
                    if (startRead)
                    {
    
                        retVal.Add(data[i]);
                        count++;
    
                        if (count == length)
                            break;
                    }
                }
                return retVal.ToArray();
            }

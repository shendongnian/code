       public static void FillFlex<T>(this Array source, T value)
        {
            bool complete = false;
            int[] indices = new int[source.Rank];
            int index = source.GetLowerBound(0);
            int totalElements = 1;
            for (int i = 0; i < source.Rank; i++)
            {
                indices[i] = source.GetLowerBound(i);
                totalElements *= source.GetLength(i);
            }
            indices[indices.Length - 1]--;
            complete = totalElements == 0;
            while (!complete)
            {
                index++;
                int rank = source.Rank;
                indices[rank - 1]++;
                for (int i = rank - 1; i >= 0; i--)
                {
                    if (indices[i] > source.GetUpperBound(i))
                    {
                        if (i == 0)
                        {
                            complete = true;
                            return;
                        }
                        for (int j = i; j < rank; j++)
                        {
                            indices[j] = source.GetLowerBound(j);
                        }
                        indices[i - 1]++;
                    }
                }
                source.SetValue(value, indices);
            }
        }

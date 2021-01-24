    void bubbleSort()
    {
        for (m = 0; m < values.Length; m++)
        {
            for (int j = 0; j < values.Length - m - 1; j++)
            {
                if (values[j] > values[j + 1])
                {
                    float temp = values[j];
                    values[j] = values[j + 1];
                    values[j + 1] = temp;
                }
            }
            Refresh();   // Invalidate would be optimized away
        }
    }

    public static int FindElement(int[] list, int nrElements, int wanted)
    {
        for (int i = 0; i <= nrElements - 1; i++)
        {
            if (list[i] == wanted)
            {
                return i;
            }
            else if (list[i] != wanted)
            {
                return -1;
            }
        }
        return 0;
    }

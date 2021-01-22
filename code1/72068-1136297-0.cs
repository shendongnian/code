    private int ReturnMaxIdx(List<int> intList)
            {
                int MaxIDX = -1;
                int Max = -1;
    
                for (int i = 0; i < intList.Count; i++)
                {
                    if (i == 0)
                    {
                        Max = intList[0];
                        MaxIDX = 0;
                    }
                    else
                    {
                        if (intList[i] > Max)
                        {
                            Max = intList[i];
                            MaxIDX = i;
                        }
                    }
                }
    
                return MaxIDX;
            }

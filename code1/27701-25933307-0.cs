       protected List<List<int>> MySplit(int MaxNumber, int Divider)
            {
                List<List<int>> lst = new List<List<int>>();
                int ListCount = 0;
                int d = MaxNumber / Divider;
                lst.Add(new List<int>());
                for (int i = 1; i <= MaxNumber; i++)
                {
                    lst[ListCount].Add(i);
                    if (i != 0 && i % d == 0)
                    {
                        ListCount++;
                        d += MaxNumber / Divider;
                        lst.Add(new List<int>());
                    }
                }
                return lst;
            }

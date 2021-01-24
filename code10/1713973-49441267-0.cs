                List<int> orderList = new List<int>(){ 1, 2, 3, 4, 5, 6, 0 };
                List<int> input = new List<int>(){ 2, 5, 6, 2, 2, 4 };
                List<List<int>> output = new List<List<int>>();
                List<int> temp = null;
                for (int i = 0; i < input.Count(); i++)
                {
                    if (i == 0)
                    {
                        temp = new List<int>();
                        output.Add(temp);
                        temp.Add(input[i]);
                    }
                    else
                    {
                        if (orderList.IndexOf(input[i]) > orderList.IndexOf(input[i - 1]))
                        {
                            temp.Add(input[i]);
                        }
                        else
                        {
                            temp = new List<int>();
                            output.Add(temp);
                            temp.Add(input[i]);
                        }
                    }
                }

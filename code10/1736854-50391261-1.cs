    private static List<int> GetNewList(List<int> numberList)
    {
        List<int> newNumList = new List<int>();
        for (int i = 0; i < numberList.Count - 1; i ++)
        {
            for(int j = i+1; j < numberList.Count; j++)
            {
                string number = "";
                foreach (char ch in numberList[j].ToString())
                {
                    number = numberList[i].ToString() + ch;
    
                    if (!IsNumRecurring(number))
                    {
                        number = String.Concat(number.OrderBy(c => c));
                        int num = int.Parse(number);
    
                        if (!newNumList.Contains(num))
                            newNumList.Add(num);
                    }
                }
            }
        }
        //Now we should check the same thing in reverse order on list.
        for (int i = numberList.Count - 1; i > 0; i--)
        {
            for (int j = i -1; j >= 0; j--)
            {
                string number = "";
                foreach (char ch in numberList[j].ToString())
                {
                    number = numberList[i].ToString() + ch;
                    if (!IsNumRecurring(number))
                    {
                        number = String.Concat(number.OrderBy(c => c));
                        int num = int.Parse(number);
                        if (!newNumList.Contains(num))
                            newNumList.Add(num);
                    }
                }
            }
        }
        return newNumList;
    }
    
    //here we will check if number is recurring
    private static bool IsNumRecurring(string num)
    {
        return num.Any(c => num.Where(ch => ch == c).Count() > 1);
    }

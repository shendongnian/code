    public static class StringListExtensions
    {
        public static void TrimAll(this List<string> stringList)
        {
            for (int i = 0; i < stringList.Count; i++)
            {
                stringList[i] = stringList[i].Trim(); //warning: do not change this to lambda expression (.ForEach() uses a copy)
            }
        }
    }

    public sealed class FSChangeElemComparerByPath : IComparer<FSChangeElem>
    {
        public int Compare(FSChangeElem firstPath, FSChangeElem secondPath)
        {
            return firstPath.strObjectPath == null ?
                (secondPath.strObjectPath == null ? 0 : -1) :
                (secondPath.strObjectPath == null ? 1 : ComparerWrap(firstPath.strObjectPath, secondPath.strObjectPath));
        }
        private int ComparerWrap(string stringA, string stringB)
        {
            int length = 0;
            int start = 0;
            List<string> valueA = new List<string>();
            List<string> valueB = new List<string>();
            ListInit(ref valueA, stringA);
            ListInit(ref valueB, stringB);
            if (valueA.Count != valueB.Count)
            {
                length = (valueA.Count > valueB.Count)
                           ? valueA.Count : valueB.Count;
                if (valueA.Count != length)
                {
                    for (int i = 0; i < length - valueA.Count; i++)
                    {
                        valueA.Add(string.Empty);
                    }
                }
                else
                {
                    for (int i = 0; i < length - valueB.Count; i++)
                    {
                        valueB.Add(string.Empty);
                    }
                }
            }
            else
                length = valueA.Count;
            return RecursiveComparing(valueA, valueB, length, start);
        }
        private void ListInit(ref List<string> stringCollection, string stringToList)
        {
            foreach (string s in stringToList.Remove(0, 2).Split('\\'))
            {
                stringCollection.Add(s);
            }
        }
        private int RecursiveComparing(List<string> valueA, List<string> valueB, int length, int start)
        {
            int result = 0;
            if (start != length)
            {
                if (valueA[start] == valueB[start])
                {
                    result = RecursiveComparing(valueA, valueB, length, ++start);
                }
                else
                {
                    result = String.Compare(valueA[start], valueB[start]);
                }
            }
            else
                return 0;
            return result;
        }
    }
}

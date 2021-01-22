    public static void StringPermutationsDemo()
    {
        strBldr = new StringBuilder();
        string result = Permute("ABCD".ToCharArray(), 0);
        MessageBox.Show(result);
    }     
    static string Permute(char[] elementsList, int startIndex)
    {
        if (startIndex == elementsList.Length)
        {
            foreach (char element in elementsList)
            {
                strBldr.Append(" " + element);
            }
            strBldr.AppendLine("");
        }
        else
        {
            for (int tempIndex = startIndex; tempIndex <= elementsList.Length - 1; tempIndex++)
            {
                Swap(ref elementsList[startIndex], ref elementsList[tempIndex]);
                Permute(elementsList, (startIndex + 1));
                Swap(ref elementsList[startIndex], ref elementsList[tempIndex]);
            }
        }
        return strBldr.ToString();
    }
    static void Swap(ref char Char1, ref char Char2)
    {
        char tempElement = Char1;
        Char1 = Char2;
        Char2 = tempElement;
    }

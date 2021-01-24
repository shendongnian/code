    static void MethodWithoutRef(int num)
    {
        num = num + 2;
    }
    static void Method(ref int num)
    {
        num = num + 2;
    }
    static void MethodWithoutRef(List<int> numList)
    {
        numList[0] = numList[0] + 2;
        numList.Add(12);
    }
    static void Method(ref List<int> numList)
    {
        numList[0] = numList[0] + 2;
        numList.Add(12);
    }

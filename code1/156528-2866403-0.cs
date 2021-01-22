    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    public static void Reverse(Array array, int index, int length)
    {
        if (array == null)
        {
            throw new ArgumentNullException("array");
        }
        if ((index < array.GetLowerBound(0)) || (length < 0))
        {
            throw new ArgumentOutOfRangeException((index < 0) ? "index" : "length", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
        }
        if ((array.Length - (index - array.GetLowerBound(0))) < length)
        {
            throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
        }
        if (array.Rank != 1)
        {
            throw new RankException(Environment.GetResourceString("Rank_MultiDimNotSupported"));
        }
        if (!TrySZReverse(array, index, length))
        {
            int num = index;
            int num2 = (index + length) - 1;
            object[] objArray = array as object[];
            if (objArray == null)
            {
                while (num < num2)
                {
                    object obj3 = array.GetValue(num);
                    array.SetValue(array.GetValue(num2), num);
                    array.SetValue(obj3, num2);
                    num++;
                    num2--;
                }
            }
            else
            {
                while (num < num2)
                {
                    object obj2 = objArray[num];
                    objArray[num] = objArray[num2];
                    objArray[num2] = obj2;
                    num++;
                    num2--;
                }
            }
        }
    }

    //from Applied Microsoft.NET framework Programming - Jeffrey Richter
    public static Array RedimPreserve(Array origArray, Int32 desiredSize)
            {
                System.Type t = origArray.GetType().GetElementType();
                Array newArray = Array.CreateInstance(t, desiredSize);
                Array.Copy(origArray, 0, newArray, 0, Math.Min(origArray.Length, desiredSize));
                return newArray;
            }

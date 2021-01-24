    public static class ObjectTypeIsEqual
    {
        public static bool CompareDataType<T>(this object input)
        {
            Type ObjectType = input.GetType();
            Type CompareType = typeof(T);
            return ObjectType.Equals(CompareType) || ObjectType.Equals(Nullable.GetUnderlyingType(CompareType));
        }
    }
    
    int? output = null;
    object RunTimeData = (object)((int)0);
    if (RunTimeData.CompareDataType<int?>())
        output = (int?)RunTimeData;

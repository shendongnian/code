    MyObjectValues.Select(currentItems=>MyTypeFactory.GetNewInstance(currentItems.Value1,
    currentItems.Value2));
    public static class MyTypeFactory
    {
        public static MyType GetNewInstance(
             typeofvalue1 value1, 
             typeofvalue2 value2)
        {
            return new MyType { Parameter1 = value1, Parameter2 = value2 };
        }
    }

    public static class SomeBusinessObjectFactory
    {
       public static SomeBusinessObject FromDataRow(IDataRecord row)
       {
           return new SomeBusinessObject() { Property1 = row["Property1"], Property2 = row["Property2"] ... };
       }
    }

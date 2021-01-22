    public class DataTypeMap : ClassMap<DataType>
    {
       public DataTypeMap()
       {
          // ...
          Map(x => x.TypeOfContent);
       }
    }

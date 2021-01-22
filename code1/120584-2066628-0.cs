    public enum MyEnum { First, Second, Third };
    public class MyApiWrapper
    {
       private Dictionary<int, int> ExternalToInternal = new Dictionary<int, int>();
       private Dictionary<int, int> InternalToExternal = new Dictionary<int, int>();
       public MyApiWrapper(List<int> externalApiEnumValues)
       {
          foreach (int i = 0; i < externalApiEnumValues.Count; i++)
          {
             ExternalToInternal[externalApiEnumValues[i]] = i;
             InternalToExternal[i] = externalApiEnumValues[i];
          }
       }
       // obviously, your real method for calling the external API 
       // will do more than this.
       public void CallApi()
       {
          CallExternalApi(_EnumValue);
       }
       private MyEnum _ExternalEnumValue;
       public MyEnum EnumValue
       {
          get { return ExternalToInternal[_ExternalEnumValue]; }
          set { _ExternalEnumValue = InternalToExternal[value]; }
       }
    }

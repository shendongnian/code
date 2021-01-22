    public interface MPropertyAsStringSettable { }
    public static class PropertyAsStringSettable {
      public static void SetPropertyAsString(
        this MPropertyAsStringSettable self, string propertyName, string value) {
        var property = TypeDescriptor.GetProperties(self)[propertyName];
        var convertedValue = property.Converter.ConvertFrom(value);
        property.SetValue(self, convertedValue);
      }
    }
    public class Ship : MPropertyAsStringSettable {
      public double Latitude { get; set; }
      // ...
    }

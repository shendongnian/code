    class Program {
       public enum EnumDisplayStatus {
        Red = 1,
         Blue = 2,
         Yellow = 3,
         Orange = 4
       }
       static void Main() {
        int value = 3;
        EnumDisplayStatus enumDisplayStatus = (EnumDisplayStatus) value;
        string color = enumDisplayStatus.ToString();
        Console.Write(color);
       }
      }

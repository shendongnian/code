    public class TextLengthAttribute : Attribute
    {
        private int length;
        public int Length { get { retrun length; } set { length = value; } }
    
        public TextLengthAttribute(int num) { this.length = num ; }
    }
    
    public class MyClass
    {
    
        [TextLength(10)]
        public string Property1;
        [TextLength(20)]
        public string Property2;
    }
    
    public class ClassReader
    {
         public static void Main()
         {
              MyClass example = MyClass.GetTestData();
    
              PropertyInfo[] props = typeof(MyClass).GetProperties();
              foreach (PropertyInfo prop in props)
              {
                   if (prop.ValueType == typeof(String) 
                   {
                        TextLengthAttribute[] atts = 
                          (TextLengthAttribute)[]prop.GetCustomAttributes(
                               typeof(TextLengthAttribute), false);
                        if (prop.GetValue(example, null).ToString().Length > 
                             atts[0].Length) 
                            throw new Exception(prop.name + " was too long");
                   }
              }
         }
    }

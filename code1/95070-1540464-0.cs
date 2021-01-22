    public class MyClass
    {
         [Description("I'm an attribute!")]
         public int MyField;
         public Attribute GetAttribute(string fieldName)
         {
              FieldInfo field = typeof(MyClass).GetField("MyField");
              Attribute[] attributes = (Attribute[])field.GetCustomAttributes(typeof(Attribute), false);
    
              DescriptionAttribute desc = (DescriptionAttribute)attributes[0];
              return desc;
         }
    }
